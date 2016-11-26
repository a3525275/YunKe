using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Optimizators.Domain;
using YunKe.Commerce.Projects.Domain;
using YunKe.Shared.Enums;

namespace YunKe.Commerce.Questions.Domain
{
    public class Question : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public QuestionCatalog QuestionCatalog { get; set; }

        public bool IsAnswered { get; set; }

        public bool Closed { get; set; }

        [StringLength(500)]
        public string Reply { get; set; }

        public DateTime RaiseDate { get; set; }

        public DateTime? ReplyDate { get; set; }

        [Required]
        [StringLength(128)]
        public string OptimizatorId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public string ProjectId { get; set; }

        [Required]
        [StringLength(128)]
        public string Domain { get; set; }

        public virtual Project Project { get; set; }
    }
}
