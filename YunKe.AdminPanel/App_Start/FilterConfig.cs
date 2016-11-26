
using System.Web.Mvc;
using YunKe.AdminPanel.Filters;

namespace YunKe.AdminPanel
{
    /// <summary>
    /// FilterConfig
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SiteExceptionAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RightFilter());
            filters.Add(new VisitFilter());
        }
    }
}
