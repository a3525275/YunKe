using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.AdminPanel;
using YunKe.Commerce.SiteTemplates.Domain;
using YunKe.Commerce.SiteTemplates.Dtos;
using YunKe.Commerce.SiteTemplates.Queries;

namespace YunKe.AdminPanel.Areas.WuYou.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CommonCRUDControllerBase{SiteTemplate,  SiteTemplateDto,  UpdateSiteTemplateDto,  SiteTemplateOverviewDto,  GetSiteTemplatesListQuery}" />
    public class SiteTemplatesController :
        CommonCRUDControllerBase<SiteTemplate, SiteTemplateDto,
            UpdateSiteTemplateDto,
             SiteTemplateOverviewDto, GetSiteTemplatesListQuery>
    {
        public SiteTemplatesController()
        {

        }
    }
}