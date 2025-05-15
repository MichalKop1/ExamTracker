using DomainModel.Models;

namespace DataAcessLayer.Contracts;

public interface IGrade8ExamRepository
{
    public event Action<string> OnError;

    public Task<List<Exam8Grade>> GetAllExams(int id);

    public Task AddExamToDB(Exam8Grade exam);

    public Task DeleteExam(int id);
}
