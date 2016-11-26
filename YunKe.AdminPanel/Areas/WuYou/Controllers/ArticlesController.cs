using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.AdminPanel;
using YunKe.Commerce.Articles.Domain;
using YunKe.Commerce.Articles.Dtos;
using YunKe.Commerce.Articles.Queries;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Service;

namespace YunKe.AdminPanel.Areas.WuYou.Controllers
{
    public class ArticlesController : CommonCRUDControllerBase<Article, Article, Article, ArticleOverviewDto, GetArticlesListQuery>
    {
        public override ActionResult GetListWithPager(GetArticlesListQuery filters)
        {
            filters.KeywordsField = nameof(Article.Title);

            if (filters.CategoryId.IsNotBlank())
            {
                filters.AdditionalQueries.Add(new KeyValuePair<string, object>($" {nameof(Article.ArticleCategoryId)} == @0 ", filters.CategoryId));
            }

            return base.GetListWithPager(filters);
        }
    }

    public class SharedArticlesController : ArticlesController
    {
        private readonly IRepository<ArticleCategory> _categoryRepository;

        public SharedArticlesController()
        {
            _categoryRepository = DependencyResolver.Current.GetService<IRepository<ArticleCategory>>();
        }

        /// <summary>
        /// Gets or sets for category code.
        /// </summary>
        /// <value>
        /// For category code.
        /// </value>
        public string ForCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of for category article.
        /// </summary>
        /// <value>
        /// The name of for category article.
        /// </value>
        public string ForCategoryArticleName { get; set; } = "文章";

        /// <summary>
        /// Gets or sets a value indicating whether the category has sub categorories].
        /// </summary>
        /// <value>
        /// <c>true</c> if [for category has sub categorories]; otherwise, <c>false</c>.
        /// </value>
        public bool ForCategoryHasSubCategorories { get; set; }


        #region Common For Specify Category Articles.

        /// <summary>
        /// Categories the articles index view.
        /// </summary>
        /// <returns></returns>
        public override ActionResult Index()
        {
            var category = _categoryRepository.Get(it => it.Code == ForCategoryCode);
            if (category == null)
            {
                category = new ArticleCategory()
                {
                    Id = ForCategoryCode,
                    Code = ForCategoryCode,
                    Name = ForCategoryArticleName,
                };

                _categoryRepository.Insert(category);
            }

            ViewBag.Title = $"{ForCategoryArticleName}管理";
            return View("_Article_ListForCategory", new YunKe.Commerce.Articles.Queries.GetArticlesListQuery()
            {
                CategoryCode = ForCategoryCode,
                CategoryId = category.Id,
            });
        }

        public override ActionResult GetListWithPager(GetArticlesListQuery filters)
        {
            var category = _categoryRepository.Get(it => it.Code == ForCategoryCode);
            filters.CategoryId = category == null ? "-" : category.Id;
            return base.GetListWithPager(filters);
        }

        /// <summary>
        /// Categories the articles index view.
        /// </summary>
        /// <returns></returns>
        public override ActionResult Add()
        {
            ViewBag.Title = $"添加{ForCategoryArticleName}";
            var category = _categoryRepository.Get(it => it.Code == ForCategoryCode);

            return View("_Article_AddForCategory", new ArticleOverviewDto()
            {
                ArticleCategoryId = category.Id,
                CategoryCode = category.Code,
                CategoryName = category.Name,
            });
        }


        /// <summary>
        /// Categories the articles index view.
        /// </summary>
        /// <returns></returns>
        public override ActionResult Edit(string id)
        {
            ViewBag.Title = $"编辑{ForCategoryArticleName}";
            var model = _mapper.Map<ArticleOverviewDto>(_repository.Get(it => it.Id == id));

            return View("_Article_EditForCategory", model);
        }

        #endregion
    }
}