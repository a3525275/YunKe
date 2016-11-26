using System;

namespace YunKe.Infrastructure.Service.Sms
{
    /// <summary>
    /// 提供 sms 短信发送 api 信息。
    /// </summary>
    public interface ISmsAccountProvider
    {
        string SmsAccount { get; set; }

        string SmsSecurity { get; set; }

        string SmsApiUrl { get; set; }
    }

    public class AppSettingSmsAccountProvider : ISmsAccountProvider
    {
        public string SmsAccount { get; set; }

        public string SmsApiUrl { get; set; }

        public string SmsSecurity { get; set; }

        public AppSettingSmsAccountProvider()
        {
            SmsAccount = System.Configuration.ConfigurationManager.AppSettings["SmsAccount"];
            SmsApiUrl = System.Configuration.ConfigurationManager.AppSettings["SmsApiUrl"];
            SmsSecurity = System.Configuration.ConfigurationManager.AppSettings["SmsPassword"];
        }
    }
}