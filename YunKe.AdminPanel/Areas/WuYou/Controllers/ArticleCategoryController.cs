using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.Commerce.Articles.Domain;
using YunKe.Infrastructure.Data.Filters;

namespace YunKe.AdminPanel.Areas.WuYou.Controllers
{
    public class ArticleCategoryController: CommonCRUDControllerBase<ArticleCategory, ArticleCategory, ArticleCategory, ArticleCategory, BaseFilter>
    {
    }
}