using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.Projects.Domain;
using YunKe.Commerce.Sites.Domain;

namespace YunKe.Commerce.SiteTemplates.Domain
{
    public class SiteTemplate : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(32)]
        public string Color { get; set; }

        [StringLength(64)]
        public string Industry { get; set; }

        [StringLength(512)]
        public string CoverImage { get; set; }

        [StringLength(1024)]
        public string Images { get; set; }

        [StringLength(1024)]
        public string TemplateFileUrl { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }
}
