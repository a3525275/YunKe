using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Shared.Enums
{
    /// <summary>
    /// 实名认证类型
    /// </summary>
    public enum RealNameValidationType
    {
        [Description("个人实名认证")]
        Person,
        [Description("企业认证")]
        Company,
    }
}
