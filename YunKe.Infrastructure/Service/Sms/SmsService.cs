using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YunKe.Infrastructure.Service.Sms
{
    /// <summary>
    /// 提供短信验证码发送和验证服务
    /// </summary>
    public interface ISmsCodeService
    {
        string SendCode(string mobile, string content, string codePlaceholder = "{code}");

        bool ValidateCode(ISmsCodeValidatingRequired target);
    }

    public class SmsCodeService : ISmsCodeService
    {
        private readonly ISmsSender _smsSender;

        public SmsCodeService(ISmsSender smsSender)
        {
            _smsSender = smsSender;
        }

        public static string createRandom()
        {
            var random = new Random(DateTime.Now.Millisecond)
                .Next(10000, 99999);
            return random.ToString();
        }


        public string SendCode(string mobile, string content, string codePlaceholder = "{code}")
        {
            var code = createRandom();
            var textToSendWithCode = content.Replace(codePlaceholder, code);

            _smsSender.SendSms(mobile, textToSendWithCode);

            return code;
        }

        public bool ValidateCode(ISmsCodeValidatingRequired target)
        {
            var lastCode = HttpContext.Current.Session["_smsCode"] as string;
            HttpContext.Current.Session["_smsCode"] = "";
            return lastCode == target?.SmsCode;
        }

    }
}
