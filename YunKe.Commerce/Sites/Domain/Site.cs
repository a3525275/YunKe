using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Projects.Domain;
using YunKe.Commerce.SiteTemplates.Domain;

namespace YunKe.Commerce.Sites.Domain
{
    public class Site : BaseEntity
    {
        [StringLength(128)]
        [Required]
        public string Domain { get; set; }

        [StringLength(128)]
        [Required]
        public string FtpAddress { get; set; }

        [StringLength(128)]
        [Required]
        public string FtpPassword { get; set; }

        [StringLength(128)]
        public string RdpAccount { get; set; }

        [StringLength(128)]
        public string RdpPassword { get; set; }
        
        [ForeignKey("SiteTemplate")]
        public string SiteTemplateId { get; set; }

        public virtual SiteTemplate SiteTemplate { get; set; }

        [Required]
        [ForeignKey("Project")]
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
