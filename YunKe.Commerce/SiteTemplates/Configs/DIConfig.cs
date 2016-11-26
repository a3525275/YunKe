using SimpleInjector;
using YunKe.AdminPanelCore.Entity;
using YunKe.AdminPanelCore.Models;
using YunKe.Commerce.SiteTemplates.Dtos;
using YunKe.Commerce.SiteTemplates.Queries;
using YunKe.Commerce.SiteTemplates.QueryHandlers;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Commands;
using YunKe.Infrastructure.Queries;

namespace YunKe.Commerce.SiteTemplates.Configs
{
    public class DIConfig
    {
        /// <summary>
        /// 注册 sevice, 如果有的话。
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Register(Container container)
        {
            container.Register<IQueryHandler<GetSiteTemplatesListQuery, PagedResult<SiteTemplateOverviewDto>>, SiteTemplateQueryHandler>();
        }
    }
}
