using DataAcessLayer.Contracts;
using DomainModel.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
namespace DataAcessLayer.Repositories;

public class MaturaExamRepository :IMaturaExamRepository
{
    public event Action<string> OnError = delegate { };
    private void AnErrorOccured(string errMsg)
    {
        OnError?.Invoke(errMsg);
    }
    public async Task<List<ExamMatura>> GetAllExams(int id)
    {
        string query = $"SELECT exam_id AS ExamId, date, exercise1, exercise2, exercise3, exercise4, exercise5, exercise6, exercise7, exercise8, exercise9, exercise10, total_score AS TotalScore FROM MaturaExams INNER JOIN Students ON Students.student_id = MaturaExams.student_id WHERE Students.student_id = @Id";
    
        try
        {
            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                return  (await connection.QueryAsync<ExamMatura>(query, id)).ToList();
            }
        }
        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return [];
        }
    }

    public async Task AddExamToDB(ExamMatura exam)
    {
        string query = "INSERT INTO MaturaExams (student_id, date, exercise1, exercise2,exercise3,exercise4,exercise5,exercise6,exercise7,exercise8,exercise9,exercise10, total_score) VALUES (@StudentId, @Date, @Exercise1, @Exercise2, @Exercise3, @Exercise4, @Exercise5, @Exercise6, @Exercise7, @Exercise8, @Exercise9, @Exercise10, @TotalScore)";
        try
        {
            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query, exam);
            }
        }
        catch(Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }
    public async Task DeleteExam(int id)
    {
        string query = $"DELETE FROM MaturaExams WHERE exam_id = @ExamId";
        try
        {
            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query, id);
            }
        }
        catch(Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }
}
