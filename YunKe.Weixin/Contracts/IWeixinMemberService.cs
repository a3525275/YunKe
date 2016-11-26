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
    public interface IWeixinMemberService
    {
        WxMemberDto GetMemberByOpenId(string openId);

        bool AddMember(WxMemberDto dto);

        bool UpdateMember(WxMemberDto dto);

        bool DeleteMember(string openId);

        bool AddOrUpdate(WxMemberDto dto);
    }
}
