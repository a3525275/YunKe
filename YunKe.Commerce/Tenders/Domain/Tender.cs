using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Customers.Domain;
using YunKe.Commerce.Optimizators.Domain;
using YunKe.Commerce.Projects.Domain;

namespace YunKe.Commerce.Tenders.Domain
{
    public class Tender : BaseEntity
    {
        public decimal Price { get; set; }

        public bool IsSettled { get; set; }

        public DateTime TendingDate { get; set; }

        public DateTime PlanCompleteDate { get; set; }

        public decimal TotalDiscount { get; set; }

        /// <summary>
        /// 优化方案
        /// </summary>
        /// <value>
        /// The plan.
        /// </value>
        [StringLength(1024)]
        public string Plan { get; set; }

        //[Required]
        [ForeignKey("Optimizator")]
        public string OptimizatorId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual Optimizator Optimizator { get; set; }

    }
}
