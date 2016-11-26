using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Optimizators.Domain;

namespace YunKe.Commerce.Projects.Domain
{
    public class OptimizationTask : BaseEntity
    {
        [Required]
        [StringLength(128)]
        [ForeignKey("Project")]
        public string ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ReceiveDate { get; set; }

        public decimal TotalIncomes { get; set; }

        public decimal TotalFree { get; set; }

        [ForeignKey("Optimizator")]
        [StringLength(128)]
        //[Required]
        public string OptimizatorId { get; set; }

        public virtual Optimizator Optimizator { get; set; }

        public virtual ICollection<OptimizationLog> Logs { get; set; }

        public OptimizationTask()
        {
            Logs = new HashSet<OptimizationLog>();
        }
    }
}
