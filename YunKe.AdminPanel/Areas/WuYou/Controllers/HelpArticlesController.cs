using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.AdminPanel;
using YunKe.Commerce.Articles.Domain;
using YunKe.Commerce.Articles.Dtos;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Validation;
using YunKe.Shared.Constants;

namespace YunKe.AdminPanel.Areas.WuYou.Controllers
{
    public class HelpArticlesController : SharedArticlesController
    {
        public HelpArticlesController()
        {
            ForCategoryCode = PredefiniedArticleCategories.HelpArticleRootCategoryCode;
            ForCategoryArticleName = "帮助文章";
            ForCategoryHasSubCategorories = true;
        }
    }
}