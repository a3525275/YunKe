using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure.Utilities;

namespace YunKe.Weixin.Entity
{
    /// <summary>
    /// 微信粉丝
    /// </summary>
    public class WxMember : BaseEntity
    {
        public WxMember()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required, StringLength(128)]
        public string OpenId { get; set; }

        [StringLength(512)]
        public string Icon { get; set; }

        [StringLength(64)]
        public string NickName { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? LastLoginDate { get; set; }

        [StringLength(128)]
        public string Province { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        public bool IsSubscribed { get; set; }

        [StringLength(128)]
        public string Country { get; set; }

        public DateTime? SubscribedDate { get; set; }

        public Gender Sex { get; set; }

        [StringLength(16)]
        public string Language { get; set; }
    }
}
