using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Dtos;

namespace YunKe.Commerce.Articles.Dtos
{
    public class ArticleOverviewDto : OverviewDtoBase
    {
        [DisplayName("标题"), Required]
        public string Title { get; set; }

        [DisplayName("摘要")]
        public string ShortDescription { get; set; }

        [DisplayName("内容")]
        public string Content { get; set; }

        [DisplayName("类别"), Required]
        public string ArticleCategoryId { get; set; }

        [DisplayName("类别代码")]
        public string CategoryCode { get; set; }

        [DisplayName("类别")]
        public string CategoryName { get; set; }

        [DisplayName("作者")]
        public string Author { get; set; }

        [DisplayName("作者链接")]
        public string AuthorLink { get; set; }

        [DisplayName("源路径")]
        public string SourceUrl { get; set; }

        [DisplayName("点赞次数")]
        public int VoteAmount { get; set; }

        [DisplayName("浏览次数")]
        public int ViewAmount { get; set; }

        [DisplayName("标签")]
        public string Tags { get; set; }

        [DisplayName("允许评论")]
        public bool AllowComment { get; set; }

        [DisplayName("评论数")]
        public int CommentsAmount { get; set; }
    }
}
