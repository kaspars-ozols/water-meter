using WaterMeter.Core.Helpers;

namespace WaterMeter.Services.Mail
{
    public static class MailgunConfig
    {
        private const string Area = "Mailgun";
        public static string BaseUrl => ConfigHelper.GetValue<string>(Area, nameof(BaseUrl));
        public static string Domain => ConfigHelper.GetValue<string>(Area, nameof(Domain));
        public static string ApiKey => ConfigHelper.GetValue<string>(Area, nameof(ApiKey));
    }
}