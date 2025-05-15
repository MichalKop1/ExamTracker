using Dapper;
using DataAcessLayer.Contracts;
using DomainModel.Models;
using System.Data;
using System.Data.SQLite;

namespace DataAcessLayer.Repositories;

public class SQLiteProductServiceRepository : IProductServiceRepository
{
    private event Action<string> OnError = delegate { };
    private void AnErrorOccured(string errMsg)
    {
        OnError?.Invoke(errMsg);
    }
    public List<ProductService> GetAllOrders()
    {
        try
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                string query = "SELECT * FROM ProductServices;";

                return connection.Query<ProductService>(query).ToList();
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return new List<ProductService>();
        }
    }

    public List<ProductService> GetAllOrdersOfTheInvoice(int invoiceId)
    {
        try
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                string query = $"SELECT * FROM ProductServices WHERE UniqueId= {invoiceId};";

                return connection.Query<ProductService>(query).ToList();
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return new List<ProductService>();
        }
    }

    public async Task InsertProductService(ProductService ps)
    {
        try
        {
            string query = @"INSERT INTO ProductServices 
                        (Description, NumberOfItems, UnitPrice, TotalGrossPrice, UniqueId) 
                        VALUES (@Description, @NumberOfItems, @UnitPrice, @TotalGrossPrice, @UniqueId)";

            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                await connection.ExecuteAsync(query, ps);
            }
        }
        catch(Exception ex)
        {
            AnErrorOccured($"Could not insert\n {ex.Message}");
        }
    }
}
