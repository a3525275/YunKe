using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunKe.Infrastructure.Extentions;
using YunKe.AdminPanelCore.Interfaces;
using YunKe.AdminPanelCore.Models;
using YunKe.AdminPanelCore.Enum;
using YunKe.AdminPanel.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Linq;
using YunKe.Infrastructure.Commands;

namespace YunKe.AdminPanel.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [IgnoreRightFilter]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMenuService _menuService;
        private readonly ICommandBus _cmdBus;

        public HomeController(IUserService userSvr, IMenuService menuService, ICommandBus cmdBus)
        {
            _userService = userSvr;
            _menuService = menuService;
            _cmdBus = cmdBus;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var myMenus = _menuService.GetMyMenus(User.Identity.GetLoginUserId());
            return View(myMenus);
        }

        /// <summary>
        /// 欢迎页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Welcome()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginDto
            {
                ReturnUrl = Request.QueryString["ReturnUrl"],
                LoginName = "admin",
                Password = "qwaszx"
            };
            return View(model);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginDto model)
        {
            if (!ModelState.IsValid) return View(model);
            model.LoginIP = HttpContext.Request.UserHostAddress;
            var loginDto = _userService.Login(model);
            if (loginDto.LoginSuccess)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var claims = new List<Claim>
                {
                    new Claim("LoginUserId", loginDto.User.Id.ToString()),
                    new Claim(ClaimTypes.Name, model.LoginName),
                    new Claim("IsSuperUser", loginDto.User.IsSuperMan.ToString())
                };
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var pro = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                authenticationManager.SignIn(pro, identity);
                if (model.ReturnUrl.IsBlank())
                    return RedirectToAction("Index");
                return Redirect(model.ReturnUrl);
            }
            ModelState.AddModelError(loginDto.Result == LoginResult.AccountNotExists ? "LoginName" : "Password",
                loginDto.Message);
            return View(model);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult UploadAvater()
        {
            return View();
        }
    }
}