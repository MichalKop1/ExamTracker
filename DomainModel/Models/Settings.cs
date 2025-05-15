namespace DomainModel.Models;

public sealed class Root
{
    public required Settings settings { get; set; } = null!;
}

public sealed class Settings
{
    public required ConnectionSettings ConnectionStrings { get; set; } = null!;
    public required AppSettings AppSettings { get; set; } = null!;
}

public sealed class ConnectionSettings
{
    public required string ExamTrackerConnectionString { get; set; } = null!;
    public required string SQLiteConnectionString { get; set; } = null!;
}

public sealed class AppSettings
{
    public required string Lang { get; set; } = null!;
    public required string RepositoryType { get; set; } = null!;
}
