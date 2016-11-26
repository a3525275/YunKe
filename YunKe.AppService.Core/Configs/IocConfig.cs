using AutoMapper;
using Mehdime.Entity;
using SimpleInjector;
using SimpleInjector.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Services;
using YunKe.Commerce.EfDbContext;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Commands;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Queries;
using YunKe.Infrastructure.RedisCacheProvider;
using YunKe.Infrastructure.Service;
using YunKe.Infrastructure.Service.Sms;
using YunKe.Weixin;

namespace YunKe.AppService.Core
{
    public class IocConfig
    {
        public static void Register(Container container)
        {
            //dbcontext
            container.Register<IDbContextScopeFactory>(() => new DbContextScopeFactory(), Lifestyle.Scoped);

            //service
            var moduleInitializers = new ModuleInitializer[]
            {
                new AdminCoreModuleInitializer(),
                new WxModuleInitializer(),
                new RedisCacheModuleInitializer(),
            };

            moduleInitializers.ForEach(x => x.LoadIoc(container));

            container.Register<ISmsCodeService, SmsCodeService>();
            container.Register<ISmsSender, SmsSender>();
            container.RegisterSingleton<ISmsAccountProvider, AppSettingSmsAccountProvider>();

            container.Register<IQueryBus, InProcessQueryBus>();
            container.Register<ICommandBus, InProgressCommandBus>();
            container.Register<IUnitOfWork, YunKeDbContextRepositoryUnitOfWork>(Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
        }
    }
}
