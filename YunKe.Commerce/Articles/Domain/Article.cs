using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;

namespace YunKe.Commerce.Articles.Domain
{
    public class Article : BaseEntity
    {
        [MaxLength(128)]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [MaxLength(128)]
        [Display(Name = "简介")]
        public string ShortDescription { get; set; }

        [Display(Name = "内容")]
        public string Content { get; set; }

        [MaxLength(128)]
        [Required]
        [Display(Name = "文章目录")]
        public string ArticleCategoryId { get; set; }

        [MaxLength(128)]
        [Display(Name = "作者")]
        public string Author { get; set; }

        [MaxLength(256)]
        [Display(Name = "作则链接")]
        public string AuthorLink { get; set; }

        [MaxLength(256)]
        [Display(Name = "来源地址")]
        public string SourceUrl { get; set; }

        [Display(Name = "点赞次数")]
        public int VoteAmount { get; set; }

        [Display(Name = "浏览次数")]
        public int ViewAmount { get; set; }

        [Display(Name = "标签")]
        [StringLength(256)]
        public string Tags { get; set; }

        [Display(Name = "允许评论")]
        public bool AllowComment { get; set; } = true;

        [ForeignKey("ArticleCategoryId")]
        public virtual ArticleCategory ArticleCategory { get; set; }

        public virtual ICollection<ArticleComment> Comments { get; set; }

        public Article()
        {
            Comments = new HashSet<ArticleComment>();
        }
    }
}
