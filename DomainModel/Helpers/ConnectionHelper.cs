using Microsoft.Extensions.Configuration;
using DomainModel.Models;

namespace DataAcessLayer;

static public class ConnectionHelper
{
	private static IConfigurationRoot config;
	public static Settings settings;

	static ConnectionHelper()
	{
		ReloadSettings();
	}

	public static void ReloadSettings()
	{
		config = new ConfigurationBuilder()
			.SetBasePath(AppContext.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

		settings = config.GetRequiredSection("settings").Get<Settings>()
			?? throw new InvalidOperationException("Settings section is null");
	}

	public static string ConnectionString
	{
		get
		{
			ReloadSettings();
			return settings.ConnectionStrings.ExamTrackerConnectionString
					?? throw new InvalidOperationException("Settings section is null");
		}
	}
	public static string SQLiteConnectionString
	{
		get
		{
			ReloadSettings();
			return settings.ConnectionStrings.SQLiteConnectionString
					?? throw new InvalidOperationException("Settings section is null");
		}
	}
}


