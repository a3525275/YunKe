using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YunKe.Commerce.SiteTemplates.Dtos
{
    public class UpdateSiteTemplateDto 
    {
        [Required, DisplayName("模板名称"), StringLength(128)]
        public string Name { get; set; }

        [Required, DisplayName("描述"), StringLength(256)]
        public string Description { get; set; }

        [Required, DisplayName("主题色")]
        [StringLength(32)]
        public string Color { get; set; }

        [Required, DisplayName("行业")]
        [StringLength(64)]
        public string Industry { get; set; }

        [Required, DisplayName("封面")]
        [StringLength(512)]
        public string CoverImage { get; set; }

        [Required, DisplayName("介绍图")]
        [StringLength(1024)]
        public string Images { get; set; }

        [Required, DisplayName("模板文件路径")]
        [StringLength(1024)]
        public string TemplateFileUrl { get; set; }

        public string Id { get; set; }
    }
}
