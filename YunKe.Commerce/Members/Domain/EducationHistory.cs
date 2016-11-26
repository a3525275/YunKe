using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YunKe.AdminPanelCore.Entity;

namespace YunKe.Commerce.Members.Domain
{
    public class EducationHistory : BaseEntity
    {
        [Required]
        [StringLength(128)]
        [ForeignKey("Member")]
        public string MemberId { get; set; }

        [StringLength(128), DisplayName("学校")]
        public string SchoolName { get; set; }

        [StringLength(128), DisplayName("专业")]
        public string MajorIn { get; set; }

        [DisplayName("开始日期")]
        public DateTime StartDate { get; set; }

        [DisplayName("结束日期")]
        public DateTime EndDate { get; set; }

        [DisplayName("全日制")]
        public bool IsFull { get; set; }

        [DisplayName("海外学习经历")]
        public bool IsOutSea { get; set; }

        [StringLength(128), DisplayName("学历")]
        public string Level { get; set; }

        [StringLength(500), DisplayName("专业描述")]
        public string Description { get; set; }

        public virtual Member Member { get; set; }
    }
}
