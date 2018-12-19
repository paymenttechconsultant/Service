using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Responses
{
    public class ConfigurationUtils
    {
       
        public static bool ShowOnlyOneServerIsBusyError = loadConfiguration("ShowOnlyOneServerIsBusyError", true);
        public static bool ShowStackTrace = loadConfiguration("ShowStackTrace", false);
        public static bool CaptchaRequired = loadConfiguration("CaptchaEnabled", false);
        public static bool LegacyAPI = loadConfiguration("LegacyAPI", true);

        public static bool loadConfiguration(string name, bool defaultValue = true)
        {
            bool bValue = true;
            if(Boolean.TryParse(WebConfigurationManager.AppSettings[name],out bValue)==false)
            {
                bValue = defaultValue;
            }
            return bValue;
        }
    }
}