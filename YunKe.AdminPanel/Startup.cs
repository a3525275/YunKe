using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YunKe.AdminPanel.Startup))]
namespace YunKe.AdminPanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
