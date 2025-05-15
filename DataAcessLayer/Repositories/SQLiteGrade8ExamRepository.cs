using Dapper;
using DataAcessLayer.Contracts;
using DomainModel.Models;
using System.Data;
using System.Data.SQLite;

namespace DataAcessLayer.Repositories;

public class SQLiteGrade8ExamRepository :IGrade8ExamRepository
{
    public event Action<string> OnError = delegate { };
    private void AnErrorOccured(string errMsg)
    {
        OnError?.Invoke(errMsg);
    }
    public async Task<List<Exam8Grade>> GetAllExams(int id)
    {
        string query = $"SELECT exam_id AS ExamId, date, exercise1, exercise2, exercise3, exercise4, exercise5, exercise6, exercise7, exercise8, exercise9, exercise10,exercise11,exercise12,exercise13,exercise14, total_score AS TotalScore FROM Grade8Exams INNER JOIN Students ON Students.student_id = Grade8Exams.student_id WHERE Students.student_id = '{id}'";

        try
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                return (await connection.QueryAsync<Exam8Grade>(query)).ToList();
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return new List<Exam8Grade>();
        }
    }

    public async Task AddExamToDB(Exam8Grade exam)
    {
        string query = "INSERT INTO Grade8Exams (student_id, date, exercise1, exercise2,exercise3,exercise4,exercise5,exercise6,exercise7,exercise8,exercise9,exercise10,exercise11,exercise12,exercise13,exercise14, total_score) VALUES (@StudentId, @Date, @Exercise1, @Exercise2, @Exercise3, @Exercise4, @Exercise5, @Exercise6, @Exercise7, @Exercise8, @Exercise9, @Exercise10,@Exercise11,@Exercise12,@Exercise13,@Exercise14, @TotalScore)";
        try
        {
            using (IDbConnection connection = new SQLiteConnection(ConnectionHelper.SQLiteConnectionString))
            {
                await connection.ExecuteAsync(query, exam);
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }

    public async Task DeleteExam(int id)
    {
        string query = $"DELETE FROM Grade8Exams WHERE exam_id = '{id}'";
        try
        {
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
