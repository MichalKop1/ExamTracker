namespace DomainModel.Models;
public class Exam8Grade
{
    public int ExamId { get; set; }
    public int StudentId { get; set; }
    public DateTime Date { get; set; }
    public int Exercise1 { get; set; }
    public int Exercise2 { get; set; }
    public int Exercise3 { get; set; }
    public int Exercise4 { get; set; }
    public int Exercise5 { get; set; }
    public int Exercise6 { get; set; }
    public int Exercise7 { get; set; }
    public int Exercise8 { get; set; }
    public int Exercise9 { get; set; }
    public int Exercise10 { get; set; }
    public int Exercise11 { get; set; }
    public int Exercise12 { get; set; }
    public int Exercise13 { get; set; }
    public int Exercise14 { get; set; }
    public int TotalScore { get; set; }

    public Exam8Grade(int studentId, DateTime date, int ex1, int ex2, int ex3, int ex4, int ex5,
        int ex6, int ex7, int ex8, int ex9, int ex10,int ex11,int ex12,int ex13, int ex14, int totalScore)
    {
        StudentId = studentId;
        this.Date = date;
        Exercise1 = ex1;
        Exercise2 = ex2;
        Exercise3 = ex3;
        Exercise4 = ex4;
        Exercise5 = ex5;
        Exercise6 = ex6;
        Exercise7 = ex7;
        Exercise8 = ex8;
        Exercise9 = ex9;
        Exercise10 = ex10;
        Exercise11 = ex11;
        Exercise12 = ex12;
        Exercise13 = ex13;
        Exercise14 = ex14;
        TotalScore = totalScore;
    }
    public Exam8Grade() { }
}
