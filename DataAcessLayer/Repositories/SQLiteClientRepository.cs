using Dapper;
using DataAcessLayer.Contracts;
using DomainModel.Models;
using System.Data;
using System.Data.SQLite;

namespace DataAcessLayer.Repositories;

public class SQLiteClientRepository : IClientRepository
{
	public async Task AddClient(Client client)
	{
		const string sql = @"
			INSERT INTO Clients 
			(CompanyName, CompanyAddress, CompanyNip, SellerId) 
			VALUES (@CompanyName, @CompanyAddress, @CompanyNip, @SellerId)";

		using IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString);

		try
		{
			await connection.ExecuteAsync(sql, client);

		}
		catch (Exception ex)
		{
			string msg = ex.Message;
		}
	}

	public async Task DeleteClient(Client client)
	{
		const string sql = "DELETE FROM Clients WHERE Id = @Id";

		using IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString);
		try
		{
			await connection.ExecuteAsync(sql, new { client.Id });
		}
		catch(Exception ex)
		{
			string m = ex.Message;
		}
	}

	public async Task<List<Client>> GetAllClients(string sellerId)
	{
		const string sql = "SELECT * FROM Clients WHERE SellerId = @sellerId";

		using IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString);

		try
		{
			var clients = await connection.QueryAsync<Client>(sql, new { sellerId });
			return clients.AsList();
		}
		catch(Exception ex)
		{
			string msg = ex.Message;
		}

		return new List<Client>();
	}

	public async Task<Client> GetClient(int id)
	{
		const string sql = "SELECT * FROM Clients WHERE client_id = @id";

		using IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString);
		return await connection.QuerySingleOrDefaultAsync<Client>(sql, new { id });
	}

	public async Task UpdateClient(Client client)
	{
		const string sql = @"
            UPDATE Clients SET 
                company_name = @CompanyName, 
                company_address = @CompanyAddress, 
                company_nip = @CompanyNip,
            WHERE client_id = @Id";

		using IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString);
		await connection.ExecuteAsync(sql, client);
	}
}
