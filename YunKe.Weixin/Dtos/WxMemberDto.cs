using System;
using System.ComponentModel.DataAnnotations;
using YunKe.Infrastructure.Utilities;

namespace YunKe.Weixin.Dtos
{
    public class WxMemberDto
    {
        public string Id { get; set; }
        public string OpenId { get; set; }

        public string NickName { get; set; }

        public string Icon { get; set; }

        public DateTime? Birthday { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public bool IsSubscribed { get; set; }

        public string Country { get; set; }

        public DateTime? SubscribedDate { get; set; }

        public Gender Sex { get; set; }

        [StringLength(16)]
        public string Language { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
