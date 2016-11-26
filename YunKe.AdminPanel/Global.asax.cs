using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YunKe.AdminPanelCore.Interfaces;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;

namespace YunKe.AdminPanel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
#if DEBUG
            MiniProfilerEF6.Initialize();
#endif
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IocConfig.Register();
            //var dbInitService = DependencyResolver.Current.GetService<IDatabaseInitService>();
            //dbInitService.Init();
        }

        protected void Application_BeginRequest()
        {
#if DEBUG
            MiniProfiler.Start();
#endif
        }

        protected void Application_EndRequest()
        {
#if DEBUG
            MiniProfiler.Stop();
#endif
        }
    }
}
