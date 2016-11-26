using AutoMapper;
using YunKe.Weixin.Entity;
using YunKe.Weixin.Contracts;
using YunKe.Weixin.Dtos;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Service;
using YunKe.AdminPanel.Filters;
using YunKe.AdminPanel.Areas.Wx.Models;
using YunKe.AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.AdminPanel.Controllers;

namespace YunKe.AdminPanel.Areas.Wx.Controllers
{
    public class MembersController : BaseController
    {
        private readonly IRepository<WxMember> _repository;

        private readonly IWeixinService _svc;
        private readonly IMapper _mapper;

        public MembersController(IRepository<WxMember> repository,
           IWeixinService svc,
           IMapper mapper)
        {
            _repository = repository;
            _svc = svc;
            _mapper = mapper;
        }

        // GET: wx/OfficalAccounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListWithPager(BaseFilter filters)
        {
            filters.KeywordsField = "NickName";
            //filters.TreeData = true;
            var result = _repository.GetDataForListPager(filters);

            var treeData = _mapper.MapPageList<WxMemberDto, WxMember>(result);

            return Json(treeData, JsonRequestBehavior.AllowGet);
        }

        #region CRUD

        public ActionResult Delete(IEnumerable<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = _repository.DeleteBatch(p => ids.Contains(p.Id));
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}