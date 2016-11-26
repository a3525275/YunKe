using AutoMapper;
using YunKe.Weixin.Dtos;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Service;
using System.Web.Mvc;
using YunKe.AdminPanel.Controllers;
using YunKe.Weixin.Entity;

namespace YunKe.AdminPanel.Areas.Wx.Controllers
{
    public class MicroSiteController : BaseController
    {
        private readonly IRepository<WxSiteMenu> _repository;
        private readonly IMapper _mapper;

        public MicroSiteController(IRepository<WxSiteMenu> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: wx/OfficalAccounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListWithPager(BaseFilter filters)
        {
            filters.KeywordsField = "";
            //filters.TreeData = true;
            var result = _repository.GetDataForListPager(filters);

            var treeData = _mapper.MapPageList<WxSiteMenuDto, WxSiteMenu>(result);

            return Json(treeData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(string wxAccountId)
        {
            return View(new WxSiteMenuDto() { WxAccountId = wxAccountId });
        }

        public ActionResult Edit(string id)
        {
            var entity = _mapper.Map<WxSiteMenuDto>(_repository.Get(p => p.Id == id));
            return View(entity);
        }


        [HttpPost]
        public ActionResult Edit(WxSiteMenuDto model)
        {
            if (ModelState.IsValid)
            {
                var isOk = RunWithCatch((ms) =>
                {
                    var isNew = false;
                    var entity = _repository.Get(it => it.Id == model.Id);
                    if (entity == null)
                    {
                        isNew = true;
                        entity = _mapper.Map<WxSiteMenu>(model);
                    }
                    else
                    {
                        entity.Link = model.Link;
                        entity.Text = model.Text;
                        entity.Icon = model.Icon;
                        entity.Sequence = model.Sequence;
                    }

                    if (isNew)
                    {
                        return _repository.Insert(entity);
                    }
                    else
                    {
                        return _repository.Update(entity, p => new object[] { entity.Id });
                    }
                });

                if (isOk)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index", model);
        }
    }
}