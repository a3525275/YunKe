﻿using System.Collections.Generic;
using System.Web.Mvc;
using YunKe.Infrastructure.Extentions;
using YunKe.AdminPanelCore.Interfaces;
using YunKe.AdminPanelCore.Models;
using YunKe.AdminPanelCore.Enum;
using YunKe.AdminPanelCore.Models.Filters;
using YunKe.AdminPanel.Filters;
using YunKe.AdminPanel.Models;

namespace YunKe.AdminPanel.Controllers
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuSvc)
        {
            _menuService = menuSvc;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult RightTest()
        {
            return Content("权限测试");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View(new MenuDto());
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            var model = _menuService.Find(id);
            return View(model);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(MenuDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _menuService.Add(dto);
                if (result.IsNotBlank())
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(MenuDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _menuService.Update(dto);
                if (result)
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult Delete(IEnumerable<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = _menuService.Delete(ids);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        [IgnoreRightFilter]
        public JsonResult GetListWithPager(MenuFilters filters)
        {
            var result = _menuService.Search(filters);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <param name="filters">查询参数</param>
        /// <returns></returns>
        [IgnoreRightFilter]
        public JsonResult GetListWithKeywords(MenuFilters filters)
        {
            filters.page = 1;
            filters.rows = 10;
            filters.ExcludeType = MenuType.Button; 
            var result = _menuService.Search(filters);
            return Json(new {value = result.rows}, JsonRequestBehavior.AllowGet);
        }
    }
}