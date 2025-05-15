using Dapper;
using DataAcessLayer.Contracts;
using DomainModel.Models;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace DataAcessLayer.Repositories;

public class SQLiteAccountRepository:IAccountRepository
{
    public event Action<string> OnError = delegate { };
    private void AnErrorOccured(string errMsg)
    {
        OnError?.Invoke(errMsg);
    }
    public Account logIn(string login)
    {
        try
        {
            string query = $"SELECT acc_id AS Id, login, password, contactName, email, businessName, city, state, zipCode, phoneNumber FROM Accounts WHERE login = '{login}'";
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                Account? account = connection.QueryFirstOrDefault<Account>(query);

                if (account != null)
                {
                    return account;
                }
                else
                {
                    return new Account();
                }
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return new Account();
        }
    }
    public int CheckForLoginDuplicates(string login)
    {
        try
        {
            string query = "SELECT login FROM Accounts WHERE login=@Login;";
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                return connection.ExecuteScalar<int>(query, new { Login = login });
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return -1;
        }

    }
    public async Task registerAnAccount(Account account)
    {
        try
        {
            string query = "INSERT INTO Accounts (login, password, email, contactName) values (@Login, @Password, @Email, @ContactName)";
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                connection.Open();
                await connection.ExecuteAsync(query, account);
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }
    public async Task updateAnAccount(Account account)
    {
        StringBuilder sb = new StringBuilder("UPDATE Accounts SET ");
        if (!string.IsNullOrWhiteSpace(account.BusinessName))
        {
            sb.Append($"businessName = @BusinessName, ");
        }
        if (!string.IsNullOrWhiteSpace(account.StreetAdress))
        {
            sb.Append($"streetAdress = @StreetAdress, ");

        }
        if (!string.IsNullOrWhiteSpace(account.City))
        {
            sb.Append($"city = @City, ");

        }
        if (!string.IsNullOrWhiteSpace(account.State))
        {
            sb.Append($"state = @State, ");

        }
        if (!string.IsNullOrWhiteSpace(account.ZipCode))
        {
            sb.Append($"zipCode = @ZipCode, ");

        }
        if (!string.IsNullOrWhiteSpace(account.ContactName))
        {
            sb.Append($"contactName = @ContactName, ");

        }
        if (!string.IsNullOrWhiteSpace(account.Email))
        {
            sb.Append($"email = @Email, ");

        }
        if (!string.IsNullOrWhiteSpace(account.PhoneNumber))
        {
            sb.Append($"phoneNumber = @PhoneNumber, ");
        }
        if ((sb.ToString()).EndsWith(", "))
        {
            sb.Remove(sb.Length - 2, 2);
        }
        sb.Append($" WHERE acc_id = @Id");


        string query = sb.ToString(); // executeasync

        using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
        {
            await connection.ExecuteAsync(query, new { account.BusinessName, account.StreetAdress, account.City, account.State, account.ZipCode, account.ContactName, account.Email, account.PhoneNumber, account.Id });
        }
    }
}
