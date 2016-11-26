using YunKe.AdminPanelCore.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YunKe.Weixin.Entity
{
    /// <summary>
    /// 微官网菜单
    /// </summary>
    public class WxSiteMenu : BaseEntity
    {
        public WxSiteMenu()
        {
            Id = Guid.NewGuid().ToString();
        }

        [MaxLength(512)]
        public string Icon { get; set; }

        [MaxLength(512)]
        public string Link { get; set; }

        [MaxLength(32)]
        public string Text { get; set; }

        [ForeignKey("WxAccount"), Required]
        public string WxAccountId { get; set; }

        [ForeignKey("WxAccountId")]
        public virtual WxOfficalAccount WxAccount { get; set; }
    }
}
