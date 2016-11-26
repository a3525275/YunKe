using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Projects.Domain;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.Commissions.Domain
{
    /// <summary>
    /// 佣金
    /// </summary>
    /// <seealso cref="YunKe.AdminPanelCore.Entity.BaseEntity" />
    public class Commission : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string MemberId { get; set; }

        public decimal Amount { get; set; }

        public PricingUnit PricingUnit { get; set; }

        public DateTime IncomeDate { get; set; }

        [StringLength(128)]
        [Required]
        [ForeignKey("Project")]
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
