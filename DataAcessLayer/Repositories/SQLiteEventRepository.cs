using Dapper;
using DataAcessLayer.Contracts;
using DomainModel.Models;
using System.Data;
using System.Data.SQLite;

namespace DataAcessLayer.Repositories;

public class SQLiteEventRepository:IEventRepository
{
    public event Action<string> OnError = delegate { };
    public void AnErrorOccured(string errMsg)
    {
        OnError?.Invoke(errMsg);
    }
    public async Task AddEventToDB(Event _event)
    {
        try
        {
            string query = "INSERT INTO Events (event_type, long_desc, short_desc, event_date, acc_id) VALUES (@EventType, @LongDesc, @ShortDesc, @EventDate, @AccId);";

            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                await connection.ExecuteAsync(query, _event);
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }
    public async Task<List<Event>> GetAllEvents(int accountId)
    {
        try
        {
            string query = $"SELECT event_type AS EventType, long_desc AS LongDesc, short_desc AS ShortDesc, event_date AS EventDate, acc_id AS AccId, event_id AS EventId FROM Events WHERE acc_id = {accountId}";

            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                return (await connection.QueryAsync<Event>(query)).ToList();
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return new List<Event>();
        }

    }
    public async Task DeleteEvent(int eventId)
    {
        try
        {
            string query = $"DELETE FROM Events where event_id = {eventId}";
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                await connection.ExecuteAsync(query);
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }
}
