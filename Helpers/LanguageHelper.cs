using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamTracker.Helpers
{
    internal class LanguageHelper
    {
        internal static string Lang
        {
            get
            {
                string? lang = ConfigurationManager.AppSettings["Lang"];

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
                string configFilePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
                // Update the configuration file
                XDocument configDoc = XDocument.Load(configFilePath);

                var appSettings = configDoc.Descendants("appSettings").FirstOrDefault();
                if (appSettings != null)
                {
                    var langElement = appSettings.Elements("add")
                                                 .FirstOrDefault(e => e.Attribute("key")?.Value == "Lang");
                    if (langElement != null)
                    {
                        langElement.SetAttributeValue("value", value);
                        configDoc.Save(configFilePath);

                        // Refresh the appSettings section to reflect the change
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                }
            }
        }
    }
}

