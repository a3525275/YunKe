using YunKe.AdminPanelCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Weixin.Entity
{
    /// <summary>
    /// 微信自定义回复
    /// </summary>
    public class WxReply : BaseEntity
    {
        public WxReply()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 关键字
        /// </summary>
        [MaxLength(200), DisplayName("关键字")]
        public string Keys { get; set; }

        [DisplayName("匹配类型")]
        public MatchType MatchType { get; set; }

        [DisplayName("回复类型")]
        public ReplyType ReplyType { get; set; }

        [DisplayName("消息类型")]
        public MessageType MessageType { get; set; }

        [DisplayName("已禁用"), Required]
        public bool IsDisabled { get; set; }

        [DisplayName("最后更新于")]
        public DateTime? LastModified { get; set; }

        [DisplayName("最后更新人")]
        public string LastModifier { get; set; }

        [Required]
        public int Type { get; set; }

        [MaxLength(128), DisplayName("活动Id")]
        public string ActivityId { get; set; }

        [DisplayName("内容")]
        public string Content { get; set; }
    }
}
