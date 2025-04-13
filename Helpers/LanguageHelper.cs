using DataAcessLayer;
using DomainModel;
using System.Text.Json;

namespace ExamTracker.Helpers
{
    internal static class LanguageHelper
    {
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
}

