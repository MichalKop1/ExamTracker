using DomainModel.Models;

namespace DataAcessLayer.Contracts;

public interface IMaturaExamRepository
{
    public event Action<string> OnError;

    public Task<List<ExamMatura>> GetAllExams(int id);

    public Task AddExamToDB(ExamMatura exam);

    public Task DeleteExam(int id);
}
