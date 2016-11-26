using System;
using System.ComponentModel.DataAnnotations;

namespace YunKe.AdminPanelCore.Entity
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SystemConfigEntity : BaseEntity
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 数据初始化是否完成
        /// </summary>
        public bool IsDataInited { get; set; }

        /// <summary>
        /// 数据初始化时间
        /// </summary>
        public DateTime DataInitedDate { get; set; }

        [StringLength(128)]
        public string SiteName { get; set; }

        [StringLength(128)]
        public string Author { get; set; }

        [StringLength(256)]
        public string FrontEndDomain { get; set; }

        public string Settings { get; set; }

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
