using AutoMapper;
using YunKe.Infrastructure;
using YunKe.AdminPanelCore.Services;
using Mehdime.Entity;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace YunKe.AdminPanel
{
    /// <summary>
    /// ioc配置
    /// </summary>
    public class IocConfig
    {
        public static void Register()
        {
            RegisterForMvc();
        }

        /// <summary>
        /// RegisterForMvc
        /// </summary>
        private static void RegisterForMvc()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            RegisterForWebApiProxyClient(container);

            AppService.Core.IocConfig.Register(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());


            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        /// <summary>
        /// RegisterForWebApiProxyClient
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterForWebApiProxyClient(Container container)
        {
            //automapper
            container.Register<IConfigurationProvider>(AutoMapperConfig.GetMapperConfiguration, Lifestyle.Singleton);
            container.Register(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(), Lifestyle.Scoped);
        }
    }
}