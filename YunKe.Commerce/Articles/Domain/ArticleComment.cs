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
    public class ArticleComment : BaseEntity
    {
        [MaxLength(500)]
        public string Content { get; set; }

        [MaxLength(128)]
        public string Author { get; set; }

        [MaxLength(256)]
        public string AuthorLink { get; set; }

        public int VoteAmount { get; set; }

        public int ViewAmount { get; set; }

        [ForeignKey("Article")]
        [Required]
        public string ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
    }
}
