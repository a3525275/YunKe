using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Weixin.Entity;
using YunKe.Weixin.Models;
using YunKe.Weixin.Dtos;

namespace YunKe.Weixin.Contracts
{
    public interface IMessageBuilder
    {
        string Build(WxMessage template, object data);
    }
}
