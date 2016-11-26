using System;
using System.ComponentModel.DataAnnotations;
using YunKe.AdminPanelCore.Entity;
using YunKe.Infrastructure.Data;
using YunKe.Infrastructure.Service.Sms;

namespace YunKe.Infrastructure.Utilities
{
    public class SiteSetting : BaseEntity, ISmsAccountProvider
    {
        [StringLength(128)]
        public string SiteName { get; set; }

        [StringLength(128)]
        public string Author { get; set; }

        [StringLength(256)]
        public string FrontEndDomain { get; set; }

        public string Settings { get; set; }

        [StringLength(256)]
        public string SmsAccount { get; set; }

        [StringLength(256)]
        public string SmsApiUrl { get; set; }

        [StringLength(256)]
        public string SmsSecurity { get; set; }

        [StringLength(128)]
        public string SmptAccount { get; set; }

        [StringLength(128)]
        public string SmptPort { get; set; }

        [StringLength(128)]
        public string Pop3 { get; set; }

        [StringLength(128)]
        public string Pop3Port { get; set; }
    }
}
