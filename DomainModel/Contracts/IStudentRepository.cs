using DomainModel.Models;

namespace DataAcessLayer.Contracts;

public interface IStudentRepository
{
    public event Action<string> OnError;

    public Task AddStudentToDB(Student student);

    public Task<List<Student>> GetAllStudents(int teacherId);

    public Task UpdateStudentInfo(Student student);
}
