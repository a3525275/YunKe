using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure;

namespace YunKe.Weixin.Entity
{
    /// <summary>
    /// 微信公众号
    /// </summary>
    public class WxOfficalAccount : BaseEntity, IMediaSourceProvider
    {
        public WxOfficalAccount()
        {
            Id = Guid.NewGuid().ToString();
            UsingWxLoginFunction = true;
            MicroSiteMenus = new HashSet<WxSiteMenu>();
        }

        /// <summary>
        /// AppId
        /// </summary>
        [MaxLength(200), Required, DisplayName("AppId")]
        public string AppId { get; set; }

        /// <summary>
        /// AppSecret
        /// </summary>
        [MaxLength(200), Required, DisplayName("AppSecret")]
        public string AppSecret { get; set; }

        [Required, DisplayName("使用微信官方登录接口")]
        public bool UsingWxLoginFunction { get; set; }

        [DisplayName("备注"), MaxLength(128)]
        public string Description { get; set; }

        /// <summary>
        /// Api入口地址， http://host+/wx/endpoint
        /// </summary>
        [DisplayName("服务器回调地址"), Required, MaxLength(128)]
        public string EndPoint { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        [DisplayName("Token"), Required, MaxLength(128)]
        public string Token { get; set; }

        /// <summary>
        /// 媒体资源服务器路径
        /// </summary>
        [DisplayName("媒体资源服务器路径"), MaxLength(128)]
        public string MediaSourceServerPath { get; set; }

        /// <summary>
        /// 微官网顶部图片
        /// </summary>
        public string MicroSiteHeaderImages { get; set; }

        public string MicroSiteName { get; set; }


        public virtual ICollection<WxSiteMenu> MicroSiteMenus { get; set; }
    }
}
