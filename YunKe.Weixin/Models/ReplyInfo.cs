using YunKe.Weixin.Entity;
using System;
using System.ComponentModel;
using YunKe.Infrastructure.Extentions;

namespace YunKe.Weixin.Models
{
    public class ReplyInfo
    {
        public ReplyInfo()
        {
            this.LastEditDate = DateTime.Now;
            this.MatchType = MatchType.Like;
            this.MessageType = MessageType.Text;
        }

        public string ActivityId { get; set; }

        public string Id { get; set; }

        [DisplayName("禁用")]
        public bool IsDisable { get; set; }

        [DisplayName("关键字")]
        public string Keys { get; set; }

        [DisplayName("最后更新时间")]
        public DateTime? LastEditDate { get; set; }

        public string LastEditor { get; set; }

        [DisplayName("匹配模式")]
        public MatchType MatchType { get; set; }

        [DisplayName("消息类型")]
        public MessageType MessageType { get; set; }

        public string MessageTypeName
        {
            get
            {
                return this.MessageType.ToDescription();
            }
        }

        [DisplayName("回复类型")]
        public ReplyType ReplyType { get; set; }

        [DisplayName("回复类型")]
        public string ReplyTypeName
        {
            get
            {
                ReplyType en = this.ReplyType;
               string str = string.Empty;
                bool flag = false;
                if (ReplyType.Subscribe == (en & ReplyType.Subscribe))
                {
                    str = str + "[关注时回复]";
                    flag = true;
                }
                if (ReplyType.NoMatch == (en & ReplyType.NoMatch))
                {
                    str = str + "[无匹配回复]";
                    flag = true;
                }
                if (ReplyType.Keys == (en & ReplyType.Keys))
                {
                    str = str + "[关键字回复]";
                    flag = true;
                }
                if (!flag)
                {
                    str = en.ToDescription();
                }
                return str;
            }
        }

        [DisplayName("创建时间")]
        public DateTime CreateDateTime { get; set; }
    }
}
