using Dapper;
using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTrackerTests.DomainModelTests;

public class DomainModelTests
{
    private string _connectionString;
    private string _databaseName;
    private SQLiteDatabaseManager _dbManager;

    private static readonly string[] _tables =
    {
        "Accounts",
        "Students",
        "Grade8Exams",
        "MaturaExams",
        "Events",
        "Invoices",
        "ProductServices",
        "Clients"
    };

    [OneTimeSetUp]
    public void Setup()
    {
        _databaseName = $"TestDatabase_{Guid.NewGuid()}.sqlite";
        _connectionString = $"Data Source={_databaseName};Version=3;";

        _dbManager = new SQLiteDatabaseManager(_connectionString);

    }

    [Test]
    public void DbManager_FileShouldExist()
    {
        Assert.That(File.Exists(_databaseName), Is.True);
    }

    [TestCase("invalid_string")]
    public void DbManager_ErrorWhileCreatingDatabase(string connString)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new SQLiteDatabaseManager(connString);
        });
    }

    [TestCaseSource(nameof(_tables))]
    public void DbManager_ShouldCreateAllTables(string tables)
    {
        using var connection = new SQLiteConnection(_connectionString);

        var tableNames = connection.Query<string>(
            "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;")
            .ToList();

        Assert.Contains(tables, tableNames);
    }


    [OneTimeTearDown]
    public void TearDown()
    {
        if (File.Exists(_databaseName))
        {
            File.Delete(_databaseName);
        }
    }
}
