using YunKe.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunKe.AdminPanel.Controllers
{
    public class BaseController : Controller
    {
        public bool RunWithCatch(Func<ModelStateDictionary, bool> action)
        {
            try
            {
                return action(ModelState);
            }
            catch (EntityFailedException ex)
            {
                ModelState.AddModelError(ex.FieldName, ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("操作失败，请检查错误!", ex);
            }

            return false;
        }

        public ActionResult RunWithCatch()
        {
            return View();
        }
    }
}