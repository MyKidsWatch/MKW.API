using System.ComponentModel;
using System.Security.AccessControl;
using System.Resources;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace MKW.Domain.Utility.Language.Email
{
    public static class EmailLangHelper
    {
        private static readonly ResourceManager _rm;

        static EmailLangHelper()
        {
            _rm = new ResourceManager("MKW.Domain.Utility.Language.Email.EmailMessage", Assembly.GetExecutingAssembly());
        }

        public static string? GetString(string key)
        {
            return _rm.GetString(key);
        }

        public static void ChangeCulture(string language)
        {
            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}