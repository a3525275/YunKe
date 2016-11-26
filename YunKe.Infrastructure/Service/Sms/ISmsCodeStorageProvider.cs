using System;
using System.Web;

namespace YunKe.Infrastructure.Service.Sms
{
    public interface ISmsCodeStorageProvider
    {
        void SetLastCode(string code);

        string GetLastCode();
    }

    public class SessionBasedSmsCodeStorageProvider : ISmsCodeStorageProvider
    {
        public const string LastSmsCodeKey = "__LastSmsCode:Session";

        public string GetLastCode()
        {
            return HttpContext.Current?.Session?[LastSmsCodeKey] as string;
        }

        public void SetLastCode(string code)
        {
            HttpContext.Current.Session[LastSmsCodeKey] = code;
        }
    }

}