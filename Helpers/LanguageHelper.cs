using DataAcessLayer;
using DomainModel;
using System.Text.Json;

namespace ExamTracker.Helpers;

internal static class LanguageHelper
{
    internal static Language GetLanguage
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

    internal static string Lang
    {
        get
        {
            ConnectionHelper.ReloadSettings();
            string lang = ConnectionHelper.settings.AppSettings.Lang;

            if (lang != null)
            {
                return lang;
            }
            else
            {
                return string.Empty;
            }
        }
        set
        {
            string jsonConfigPath = Path.Join(Directory.GetCurrentDirectory(),"appsettings.json");

            if (File.Exists(jsonConfigPath))
            {
                string jsonString = File.ReadAllText(jsonConfigPath);

                Settings? settings = JsonSerializer.Deserialize<Settings>(jsonString);
                if (settings != null)
                {
                    settings.AppSettings.Lang = value;
                }
                string modifiedJson = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonConfigPath, modifiedJson);

                ConnectionHelper.settings.AppSettings.Lang = value;
            }
        }
    }
}

internal enum Language
{
    Polish_Pl,
    English_Us
}