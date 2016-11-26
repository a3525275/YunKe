using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YunKe.Infrastructure.Service.Sms
{
    /// <summary>
    /// 定义了可以发送短信功能的程序。
    /// </summary>
    public interface ISmsSender
    {
        void SendSms(string mobile, string content);
    }
}
