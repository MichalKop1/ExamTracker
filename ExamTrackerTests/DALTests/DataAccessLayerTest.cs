using DataAcessLayer;
using DomainModel.Models;
using Microsoft.Extensions.Configuration;

namespace ExamTrackerTests.DALTests;

public class DataAccessLayerTest
{
    private Settings _settings;

    [OneTimeSetUp]
    public void Setup()
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData"))
                .AddJsonFile("appsettings.json")
                .Build();

        _settings = config.GetRequiredSection("settings").Get<Settings>()
            ?? throw new InvalidOperationException("Setting section is null");
    }

    [TestCase("Data Source=.\\ExamTrackerDB.db;")]
    public void GetSQLiteConnectionString_ReturnsValidString(string connectionString)
    {
        var actual = _settings.ConnectionStrings.SQLiteConnectionString;

        Assert.That(actual, Is.EqualTo(connectionString));
    }
}