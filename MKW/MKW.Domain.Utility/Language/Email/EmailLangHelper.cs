using System.Globalization;
using System.Reflection;
using System.Resources;

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