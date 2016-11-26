using System;
using AutoMapper;
using SimpleInjector;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.SiteTemplates.Domain;
using YunKe.Commerce.SiteTemplates.Dtos;

namespace YunKe.Commerce.SiteTemplates.Configs
{
    public class SiteTemplateAutoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SiteTemplateDto, SiteTemplate>().ReverseMap();

            CreateMap<SiteTemplate, SiteTemplateOverviewDto>()
                .ForMember(it => it.SitesRelated, m => m.ResolveUsing(s => s.Sites.Count));

            CreateMap<UpdateSiteTemplateDto, SiteTemplate>();
        }
    }
}
