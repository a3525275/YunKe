using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Weixin.Models
{
    public class TextReplyInfo : ReplyInfo
    {
        /// <summary>
        /// 回复内容
        /// </summary>
        [DisplayName("回复内容"), Required, MaxLength(200)]
        public string Text { get; set; }
    }
}
