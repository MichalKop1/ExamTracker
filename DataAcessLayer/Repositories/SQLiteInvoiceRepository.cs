using System.Data;
using System.Data.SQLite;
using Dapper;
using DataAcessLayer.Contracts;
using DomainModel.Models;

namespace DataAcessLayer.Repositories;

public class SQLiteInvoiceRepository : IInvoiceRepository
{
    private event Action<string> OnError = delegate { };
    private void AnErrorOccured(string errMsg)
    {
        OnError?.Invoke(errMsg);
    }
    public Invoice GetInvoice(int id)
    {
        try
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                string query = $"SELECT * FROM Invoices WHERE UniqueIdentifier={id};";
                return connection.QueryFirst<Invoice>(query);
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return new Invoice();
        }
    }
    public async Task<List<Invoice>> GetAllInvoicesOfAnAccount(int accId)
    {
        try
        {
            string query = $"SELECT * FROM Invoices WHERE AccountId = {accId};";

            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                return (await connection.QueryAsync<Invoice>(query)).ToList();
            }

        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return new List<Invoice>();
        }
    }
    public async Task InsertInvoice(Invoice invoice)
    {
        try
        {
            string query = @"INSERT INTO Invoices 
                (InvoiceNumber, DateOfIssue, DateOfSale, DateOfPayment, PaymentMethod, Buyer, BuyersAddress, Seller, SellersAddress, NumberOfAccount, Currency, Remarks, TotalGross, TotalNet, AccountId, UniqueIdentifier) 
                VALUES (@InvoiceNumber, @DateOfIssue, @DateOfSale, @DateOfPayment, @PaymentMethod, @Buyer, @BuyersAddress, @Seller, @SellersAddress, @NumberOfAccount, @Currency, @Remarks, @TotalGross, @TotalNet, @AccountId, @UniqueIdentifier);";

            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                await connection.ExecuteAsync(query, invoice).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured($"Could not insert\n {ex.Message}");
        }
    }
}
