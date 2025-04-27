using Microsoft.Extensions.DependencyInjection;
using ExamTracker.UI;
using DataAcessLayer.Contracts;
using DataAcessLayer.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataAcessLayer;
using DomainModel.Models;
using DomainModel.Contracts;
using ExamTracker.Utilities;

namespace ExamTracker;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        ServiceCollection services = ConfigureServices();
        ServiceProvider serviceProvider = services.BuildServiceProvider();

        var startForm = serviceProvider.GetRequiredService<MainForm>();
        CheckForDataBases();
        Application.Run(startForm);
    }
    static ServiceCollection ConfigureServices()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        Settings? settings = config.GetRequiredSection("Settings").Get<Settings>();
        ServiceCollection services = new ServiceCollection();

        if (settings?.AppSettings.RepositoryType == "sqlServer")
        {
            services.AddTransient<IAccountRepository>(_ => new AccountRepository());
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IGrade8ExamRepository, Grade8ExamRepository>();
            services.AddTransient<IMaturaExamRepository, MaturaExamRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IDbConnection>(_ => new SqlConnection(settings.ConnectionStrings.ExamTrackerConnectionString));

        }
        else if (settings?.AppSettings.RepositoryType == "sqlite")
        {
            services.AddTransient<IAccountRepository, SQLiteAccountRepository>();
            services.AddTransient<IGrade8ExamRepository, SQLiteGrade8ExamRepository>();
            services.AddTransient<IMaturaExamRepository, SQLiteMaturaExamRepository>();
            services.AddTransient<IStudentRepository, SQLiteStudentRepository>();
            services.AddTransient<IEventRepository, SQLiteEventRepository>();
            services.AddTransient<IInvoiceRepository, SQLiteInvoiceRepository>();
            services.AddTransient<IProductServiceRepository, SQLiteProductServiceRepository>();
			services.AddTransient<IClientRepository, SQLiteClientRepository>();
			services.AddTransient<IDbConnection>(_ => new SqlConnection(settings.ConnectionStrings.SQLiteConnectionString));
        }

        services.AddMemoryCache();
        services.AddSingleton<ICacheService, CacheService>();
        services.AddSingleton<ISessionService, SessionService>();
		services.AddSingleton<IServiceFactory, ServiceFactory>();
		services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
		services.AddSingleton<MainFormUtilities>();
		services.AddSingleton<RegisterPageUtilities>();
		services.AddSingleton<StudentsControlUtility>();


		services.AddTransient<MainForm>();
        services.AddTransient<MainAppView>();

        return services;
    }

    static void CheckForDataBases()
    {
        SQLiteDatabaseManager dbManager = new SQLiteDatabaseManager(ConnectionHelper.SQLiteConnectionString);   
    }
}