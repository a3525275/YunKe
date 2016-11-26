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
    /// 微信专题
    /// </summary>
    public class WxTopic : BaseEntity
    {
        public WxTopic()
        {
            Id = Guid.NewGuid().ToString();
            IsRelease = true;
        }

        [MaxLength(200), DisplayName("标题")]
        public string Title { get; set; }

        [MaxLength(300), DisplayName("图标图片")]
        public string IconUrl { get; set; }

        [Required, DisplayName("已发布")]
        public bool IsRelease { get; set; }

        [Required, DisplayName("简介"), StringLength(200)]
        public string ShortBrief { get; set; }

        [Required, DisplayName("浏览次数")]
        public int ViewCount { get; set; }

        [DisplayName("内容")]
        public string Content { get; set; }
    }
}
