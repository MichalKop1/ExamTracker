using Microsoft.Extensions.DependencyInjection;
using ExamTracker.UI;
using DataAcessLayer.Contracts;
using DataAcessLayer.Repositories;
using System.Configuration;
using System.ServiceProcess;
using System;
using System.Data.SqlClient;
using System.Data;
namespace ExamTracker
{
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
            //Form1
            var startForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(startForm);
        }

        static ServiceCollection ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            //if (ConfigurationManager.AppSettings["repositoryType"] == "ddd")
            //{
            //    services.AddTransient<IAccountRepository>(_ => new AccountRepository());
            //}
            //else
            //{
            //    services.AddTransient<IAccountRepository>(_ => new AccountRepository());
            //}
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, CacheService>();
            services.AddTransient<IDbConnection>(_ => new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            //services.AddTransient<IAccountRepository>(_ => new AccountRepository());
            //services.AddTransient<IGrade8ExamRepository>(_ => new Grade8ExamRepository());
            //services.AddTransient<IMaturaExamRepository>(_ => new MaturaExamRepository());
            //services.AddTransient<IStudentRepository>(_ => new StudentRepository());

            services.AddSingleton<ISessionService, SessionService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IGrade8ExamRepository, Grade8ExamRepository>();
            services.AddTransient<IMaturaExamRepository, MaturaExamRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<MainForm>();
            services.AddTransient<MainAppView>();

            return services;
        }
    }
}