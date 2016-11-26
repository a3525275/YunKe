using YunKe.Weixin.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YunKe.Weixin.Models
{
    public class NewsMsgInfo
    {
        [DisplayName("内容")]
        public string Content { get; set; }

        [DisplayName("摘要"), Required, MaxLength(200)]
        public string Description { get; set; }

        public string Id { get; set; }

        [DisplayName("封面图片"), Required]
        public string PicUrl { get; set; }

        public NewsReplyInfo Reply { get; set; }

        [DisplayName("标题"), Required, MaxLength(64)]
        public string Title { get; set; }

        [DisplayName("自定义Url")]
        public string Url { get; set; }

        public bool AllowNoMatchReply { get; set; }
        public bool AllowSubscribeReply { get; set; }

        public bool KeyReply { get; set; }

        public bool NoMatchReply { get; set; }

        public bool SubscribeReply { get; set; }

        public void Setup()
        {
            KeyReply = ReplyType.Keys == (Reply.ReplyType & ReplyType.Keys);
            NoMatchReply = ReplyType.NoMatch == (Reply.ReplyType & ReplyType.NoMatch);
            SubscribeReply = ReplyType.Subscribe == (Reply.ReplyType & ReplyType.Subscribe);
        }
    }
}