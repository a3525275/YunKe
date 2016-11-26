using AutoMapper;
using YunKe.Commerce.Articles.Domain;
using YunKe.Commerce.Articles.Dtos;

namespace YunKe.Commerce.Articles.Configs
{
    public class ArticlesAutoMappingConfig : Profile
    {
        public ArticlesAutoMappingConfig()
        {
        }

        protected override void Configure()
        {
            CreateMap<Article, ArticleOverviewDto>()
                .ForMember(it => it.CategoryCode, m => m.ResolveUsing(s => s.ArticleCategory.Code))
                .ForMember(it => it.CategoryName, m => m.ResolveUsing(s => s.ArticleCategory.Name))
                .ForMember(it => it.CommentsAmount, m => m.ResolveUsing(s => s.Comments.Count));
        }
    }
}
