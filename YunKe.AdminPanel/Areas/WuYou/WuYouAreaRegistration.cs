using System.Web.Mvc;

namespace YunKe.AdminPanel.Areas.WuYou
{
    public class WuYouAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WuYou";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WuYou_default",
                "WuYou/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}