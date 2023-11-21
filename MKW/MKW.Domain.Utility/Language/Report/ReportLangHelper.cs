using System.Globalization;
using System.Reflection;
using System.Resources;

namespace MKW.Domain.Utility.Language.Report
{
    public static class ReportLangHelper
    {
        private static readonly ResourceManager _status;
        private static readonly ResourceManager _reason;

        static ReportLangHelper()
        {
            _status = new ResourceManager("MKW.Domain.Utility.Language.Report.ReportStatus", Assembly.GetExecutingAssembly());
            _reason = new ResourceManager("MKW.Domain.Utility.Language.Report.ReportReason", Assembly.GetExecutingAssembly());
        }

        public static string GetStatus(string key, string language = "pt-BR")
        {
            ChangeCulture(language);
            return _status.GetString(key)!;
        }

        public static string GetReason(string key, string language = "pt-BR")
        {
            ChangeCulture(language);
            return _reason.GetString(key)!;
        }

        public static void ChangeCulture(string language)
        {
            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
