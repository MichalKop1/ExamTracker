using DataAcessLayer;
using DomainModel.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;


namespace ExamTracker.Helpers;

public static class LanguageHelper
{
    public static Language GetLanguage
    {
        get
        {
			ConnectionHelper.ReloadSettings();
			string lang = ConnectionHelper.settings.AppSettings.Lang;

            if (Enum.TryParse(lang, ignoreCase: true, out Language result))
            {
                return result;
            }
            return Language.English_Us;
        }

        set
        {
            string jsonConfigPath = Path.Join(Directory.GetCurrentDirectory(), "appsettings.json");

            if (File.Exists(jsonConfigPath))
            {
                string jsonString = File.ReadAllText(jsonConfigPath);

                Settings? settings = JsonSerializer.Deserialize<Settings>(jsonString);
                if (settings != null)
                {
                    settings.AppSettings.Lang = value.ToString();
                }
                string modifiedJson = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonConfigPath, modifiedJson);

                ConnectionHelper.settings.AppSettings.Lang = value.ToString();
            }
        }
    }

    private static Base localization;

	public static Base Localization
	{
		get
		{
			if (localization == null)
			{
                LoadLocalization();
			}

			return localization;
		}
	}

    public static void LoadLocalization()
    {
		IConfigurationRoot config = new ConfigurationBuilder()
			.SetBasePath(AppContext.BaseDirectory)
		    .AddJsonFile("appsettings.json")
		    .Build();

        DomainModel.Models.Settings settings = config.GetRequiredSection("settings").Get<DomainModel.Models.Settings>();

        var language = settings.AppSettings.Lang;

		var jsonLanguagesFilePath = Path.Join(Directory.GetCurrentDirectory(), $"Common\\Localization_{language}.json");

		var jsonLanguages = File.ReadAllText(jsonLanguagesFilePath);
		localization = JsonSerializer.Deserialize<Base>(jsonLanguages);

	}
}

public enum Language
{
    Polish_Pl,
    English_Us
}