using DataAcessLayer.Contracts;
using DomainModel.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DataAcessLayer.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ICacheService _cacheService;
    public event Action<string> OnError = delegate { };

    private void AnErrorOccured(string errMsg)
    {
        OnError?.Invoke(errMsg);
    }

    public Student GetStudent(int id)
    {
        var cacheKey = $"Student_{id}";
        var student = _cacheService.Get<Student>(cacheKey);

        if (student == null)
        {
            // Retrieve from database
            using (IDbConnection connection = new SqlConnection())
            {
                string query = "SELECT * FROM Students WHERE Id = @Id";
                student = connection.QueryFirstOrDefault<Student>(query);
            }

            if (student != null)
            {
                _cacheService.Set(cacheKey, student, TimeSpan.FromMinutes(10));
            }
        }

        if (student != null) return student;
        else return new Student();
    }

    public async Task AddStudentToDB(Student student)
    {
        try
        {
            string query = "INSERT INTO Students (name, surname, age, email, examType, teacher_id) values (@Name, @Surname, @Age, @Email, @ExamType,@TeacherId)";
            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query, student);
            }
        }

        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }

    public async Task<List<Student>> GetAllStudents(int teacherId)
    {
        try
        {
            string query = $"SELECT student_id AS Id, name, surname, examType, age, email FROM Students WHERE teacher_id = {teacherId}";
            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                return (await connection.QueryAsync<Student>(query)).ToList();
            }
        }

        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
            return [];
        }
    }
    public async Task UpdateStudentInfo(Student student)
    {
        string query = $"UPDATE Students SET name = '{student.Name}', surname = '{student.Surname}', email = '{student.Email}'";

        if (student.Age >0)
        {
            query += $", age = {student.Age}";
        }

        query += $" WHERE student_id = {student.Id};";

        try
        {
            using (IDbConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                await connection.ExecuteAsync(query);
            }
        }

        catch (Exception ex)
        {
            AnErrorOccured(ex.Message);
        }
    }
    public StudentRepository(ICacheService cacheService)
    {

        _cacheService = cacheService;
    }
}
