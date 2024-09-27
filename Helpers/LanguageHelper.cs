using System.Configuration;
using System.Xml.Linq;
using DataAcessLayer;
using DomainModel;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExamTracker.Helpers
{
    internal class LanguageHelper
    {
  
        internal static string Lang
        {
            get
            {
                // old config code
                //string? lang = ConfigurationManager.AppSettings["Lang"];
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
                //string configFilePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
                //string configFilePath = "ExamTracker.dll.config";
                // Update the configuration file
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

                //XDocument configDoc = XDocument.Load(configFilePath);

                //var appSettings = configDoc.Descendants("appSettings").FirstOrDefault();
                //if (appSettings != null)
                //{
                //    var langElement = appSettings.Elements("add")
                //                                 .FirstOrDefault(e => e.Attribute("key")?.Value == "Lang");
                //    if (langElement != null)
                //    {
                //        langElement.SetAttributeValue("value", value);
                //        configDoc.Save(configFilePath);

                //        // Refresh the appSettings section to reflect the change
                //        ConfigurationManager.RefreshSection("appSettings");
                //    }
                //}
            }
        }
    }
}

