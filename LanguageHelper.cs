using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTracker
{
    internal class LanguageHelper
    {
        internal static string Lang
        {
            get
            {
                string? lang = ConfigurationManager.AppSettings["Lang"];
                
                if (lang!= null)
                {
                    return lang;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
