using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.AdminPanel.Controllers;

namespace YunKe.AdminPanel.Areas.Wx.Controllers
{
    public class ArticlesController : BaseController
    {
        // GET: wx/OfficalAccounts
        public ActionResult Index()
        {
            return View();
        }
    }
}