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
    public interface IWeixinService
    {
        IList<ReplyInfo> GetReplies(ReplyType topic);

        ReplyInfo GetMismatchReply();

        WxMenuDto GetMenu(string menuId);

        ReplyInfo GetReply(string replyId);

        ReplyInfo GetSubscribeReply();

        WxTopicDto Gettopic(string topicId);

        PublishWxMenuResponse PublishMenus();

        bool HasReplyKey(string key);

        void SendNotification(SendNotificationModel model);

        WxOfficalAccount GetWxAccountByName(string name = "Default");

        IList<NewsMsgInfo> GetNewsReplyInfo(string id);
    }
}
