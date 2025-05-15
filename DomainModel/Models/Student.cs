namespace DomainModel.Models;
public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int? Age { get; set; }
    public string? Email { get; set; }
    public string? ExamType { get; set; }
    public int? TeacherId { get; set; }

    public Student(string name, string surname, int age, string email, string examType, int teacherId)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Email = email;
        ExamType = examType;
        TeacherId = teacherId;
    }
    public Student(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

    public Student(string name, string surname, string email, int age, int id)
    {
        Name=name;
        Surname = surname;
        Age = age;
        Email = email;
        Id = id;
    }

    public Student() { }
}
