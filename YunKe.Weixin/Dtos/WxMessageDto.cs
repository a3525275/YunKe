using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Weixin.Dtos
{
    public class WxMessageDto
    {
        public string Id { get; set; }

        [MaxLength(128), DisplayName("回复Id")]
        public string ReplyId { get; set; }

        [MaxLength(200), DisplayName("标题")]
        public string Title { get; set; }

        [MaxLength(255), DisplayName("图片路径")]
        public string ImageUrl { get; set; }

        [MaxLength(255), DisplayName("链接")]
        public string Url { get; set; }

        [MaxLength(2000), DisplayName("描述")]
        public string Description { get; set; }

        [DisplayName("内容")]
        public string Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreateDateTime { get; set; }
    }
}
