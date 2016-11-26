using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimpleInjector;
using YunKe.Infrastructure;
using YunKe.Commerce.SiteTemplates.Configs;
using YunKe.Commerce.FriendLinks.Configs;
using YunKe.Commerce.Articles.Configs;

namespace YunKe.AppService.Core
{
    public class YunKeModuleInitializer : ModuleInitializer
    {
        public override void LoadAutoMapper(IMapperConfiguration cofig)
        {
            cofig.AddProfile<FriendLinksAutoMappingProfile>();
            cofig.AddProfile<SiteTemplateAutoMappingProfile>();
            cofig.AddProfile<ArticlesAutoMappingConfig>();
        }

        public override void LoadIoc(Container container)
        {
            // Others
            YunKe.Commerce.Articles.Configs.DIConfig.Register(container);

            YunKe.Commerce.FriendLinks.Configs.FriendLinksDIConfig.Register(container);
            YunKe.Commerce.SiteTemplates.Configs.DIConfig.Register(container);
        }
    }
}
