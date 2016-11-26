using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Service.Sms
{
    /// <summary>
    /// 提供短信的发送和验证服务。
    /// </summary>
    public interface ISmsService
    {
        string SendSms(string mobile, string text);

        bool ValidateCode(ISmsCodeValidatingRequired target);
    }

    /// <summary>
    /// Provide data for the <see cref="ISmsService"/>'s ValidateCode method.
    /// </summary>
    public interface ISmsCodeValidatingRequired
    {
        /// <summary>
        /// Gets or sets the SMS code.
        /// </summary>
        /// <value>
        /// The SMS code.
        /// </value>
        string SmsCode { get; set; }
    }
}
