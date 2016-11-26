using AutoMapper;
using YunKe.Weixin.Entity;
using YunKe.Weixin.Contracts;
using YunKe.Weixin.Dtos;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Service;
using YunKe.AdminPanel.Areas.Wx.Models;
using YunKe.AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.AdminPanel.Controllers;
using YunKe.AdminPanel.Help;

namespace YunKe.AdminPanel.Areas.Wx.Controllers
{
    public class MenusController : BaseController
    {
        private readonly IRepository<WxMenu> _repository;

        private readonly IRepository<WxTopic> _topicsRepository;

        private readonly IRepository<WxReply> _wxReplyRepository;
        private readonly IRepository<WxMessage> _wxMsgRepository;

        private readonly IWeixinService _svc;
        private readonly IMapper _mapper;

        public MenusController(IRepository<WxMenu> menuRepository,
            IRepository<WxReply> replyRepo,
           IRepository<WxTopic> topicRepo,
           IRepository<WxMessage> msgRepo,
           IWeixinService svc,
           IMapper mapper)
        {
            _repository = menuRepository;
            _topicsRepository = topicRepo;
            _wxReplyRepository = replyRepo;
            _wxMsgRepository = msgRepo;
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
            filters.TreeData = true;
            var result =  _repository.GetDataForListPager(filters);

            var treeData = _mapper.MapPageList<WxMenuDto, WxMenu>(result);

            return Json(treeData, JsonRequestBehavior.AllowGet);
        }

        #region CRUD
        public ActionResult Add(BindType? bind, string parentId)
        {
            var model = new WxMenuModel()
            {
                Bind = bind.GetValueOrDefault(),
                ParentId = parentId
            };

            model.BindTypes = SelectListItems.FromEnum(bind.GetValueOrDefault()).ToArray();

            model.Keywords = _wxReplyRepository.Query()
                .Select(x => new { x.Sequence, x.Id, x.Content })
                .OrderByDescending(x => x.Sequence)
                .ToList()
                .Select(x => new SelectListItem { Value = x.Id, Text = x.Content }).ToArray();

            model.Topics = new SelectListItem[] { };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(WxMenuModel model)
        {
            if (ModelState.IsValid)
            {
                var isOk = RunWithCatch((ms) =>
                {
                    var entity = new WxMenu();
                    entity.Name = model.Name;
                    entity.Content = model.BindValue;
                    entity.Bind = model.Bind;
                    entity.Type = model.BindType;
                    entity.ParentId = model.ParentId;
                    entity.Sequence = model.Sequence;

                    BindType bindType = model.Bind;
                    switch (bindType)
                    {
                        case BindType.Key:
                            entity.ReplyId = model.BindValue;
                            break;
                        case BindType.Topic:
                            entity.Content = model.BindTopic;
                            break;
                        default:
                            if (bindType == BindType.Url)
                            {
                                entity.Content = model.Url;
                            }
                            break;
                    }
                    entity.Client = MenuClient.Weixin;
                    entity.Type = "click";
                    if (entity.ParentId.IsBlank())
                    {
                        entity.Type = "view";
                    }
                    else if (entity.Bind == BindType.None)
                    {
                        ms.AddModelError("Bind", "二级菜单必须绑定一个对象");
                        return false;
                    }

                    _repository.Insert(entity);
                    return true;
                });

                if (isOk)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                model.BindTypes = SelectListItems.FromEnum(model.Bind).ToArray();

                model.Keywords = _wxReplyRepository.Query()
                    .Select(x => new { x.Sequence, x.Id, x.Content })
                    .OrderByDescending(x => x.Sequence)
                    .ToList()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id,
                        Text = x.Content,
                        Selected = model.BindValue == x.Id
                    }).ToArray();

                model.Topics = new SelectListItem[] { };
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var menu = _repository.Get(p => p.Id == id);

            var model = new WxMenuModel();
            model.Id = menu.Id;
            model.Bind = menu.Bind;
            model.BindTopic = menu.Content;
            model.BindValue = menu.ReplyId;
            model.Name = menu.Name;
            model.CreateDateTime = menu.CreateDateTime;
            model.Url = menu.Content;
            model.Sequence = menu.Sequence;

            model.ParentMenu = _repository.Get(x => x.Id == menu.ParentId);

            model.BindTypes = SelectListItems.FromEnum(menu.Bind).ToArray();

            model.Keywords = _wxReplyRepository.Query()
                .Select(x => new { x.Sequence, x.Id, x.Content })
                .OrderByDescending(x => x.Sequence)
                .ToList()
                .Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.Content,
                    Selected = x.Id == menu.Content
                }).ToArray();

            model.Topics = new SelectListItem[] { };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(WxMenuModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _repository.Get(p => p.Id == model.Id);

                var isOk = RunWithCatch((ms) =>
                {
                    entity.Name = model.Name;
                    entity.Content = model.BindValue;
                    entity.Bind = model.Bind;
                    entity.Type = model.BindType;
                    entity.Sequence = model.Sequence;

                    BindType bindType = model.Bind;
                    switch (bindType)
                    {
                        case BindType.Key:
                            entity.ReplyId = model.BindValue;
                            break;
                        case BindType.Topic:
                            entity.Content = model.BindTopic;
                            break;
                        default:
                            if (bindType == BindType.Url)
                            {
                                entity.Content = model.Url;
                            }
                            break;
                    }
                    entity.Client = MenuClient.Weixin;
                    entity.Type = "click";
                    if (entity.ParentId.IsBlank())
                    {
                        entity.Type = "view";
                    }
                    else if (entity.Bind == BindType.None)
                    {
                        ms.AddModelError("Bind", "二级菜单必须绑定一个对象");
                        return false;
                    }

                    _repository.Update(entity, p => new object[] { entity.Id });
                    return true;
                });

                if (isOk)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                model.BindTypes = SelectListItems.FromEnum(model.Bind).ToArray();

                model.Keywords = _wxReplyRepository.Query()
                    .Select(x => new { x.Sequence, x.Id, x.Content })
                    .OrderByDescending(x => x.Sequence)
                    .ToList()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id,
                        Text = x.Content,
                        Selected = model.BindValue == x.Id
                    }).ToArray();

                model.Topics = new SelectListItem[] { };
            }
            return View(model);
        }

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

        [HttpPost]
        public ActionResult SaveToWeixin()
        {
            var result = new JsonResultModel<bool>();

            result.RunWithCatch(r =>
              {
                  var resp = _svc.PublishMenus();

                  r.flag = resp.Succee;
                  r.msg = resp.ToString();
              });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}