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
    public class OptimizationLog : BaseEntity
    {
        [Required]
        [StringLength(128)]
        [ForeignKey("Task")]
        public string TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual OptimizationTask Task { get; set; }

        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        [StringLength(128)]
        public string OptimizatorId { get; set; }
    }
}
