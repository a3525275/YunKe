using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YunKe.Commerce.Projects.Domain
{
    public class SiteSeoInfo
    {
        public int DomainAge { get; set; }

        public int BaiduWeight { get; set; }

        public int IncludeAmount { get; set; }

        /// <summary>
        /// 反链接数
        /// </summary>
        /// <value>
        /// The links amount.
        /// </value>
        [DisplayName("反链接数")]
        public int LinksAmount { get; set; }

        [DisplayName("同IP网站数")]
        public int SitesAmountWithSameIP { get; set; }

        [StringLength(128), DisplayName("国内备案")]
        public string ServeRecord { get; set; }

        [DisplayName("快照时间")]
        public DateTime SnapshotDate { get; set; }

        [DisplayName("FTP后台")]
        public bool HasFtp { get; set; }

        [StringLength(128), DisplayName("所属区域")]
        public string Area { get; set; }
    }
}