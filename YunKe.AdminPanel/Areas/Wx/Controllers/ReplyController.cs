using AutoMapper;
using YunKe.AdminPanel.Filters;
using System;
using System.Linq;
using System.Web.Mvc;
using YunKe.AdminPanel.Areas.Wx.Models;
using YunKe.Weixin.Dtos;
using YunKe.Infrastructure.Data.Filters;
using YunKe.Infrastructure.Extentions;
using YunKe.Infrastructure.Service;
using YunKe.AdminPanel.Controllers;
using YunKe.Weixin.Entity;
using YunKe.Weixin.Contracts;
using YunKe.Weixin.Models;

namespace YunKe.AdminPanel.Areas.Wx.Controllers
{
    public class ReplyController : BaseController
    {
        private readonly IRepository<WxMenu> _repository;

        private readonly IRepository<WxTopic> _topicsRepository;

        private readonly IRepository<WxReply> _wxReplyRepository;
        private readonly IRepository<WxMessage> _wxMsgRepository;

        private readonly IWeixinService _svc;
        private readonly IMapper _mapper;

        public ReplyController(IRepository<WxMenu> menuRepository,
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

        // GET: wx/Reply
        public ActionResult Index()
        {
            return View();
        }

        [IgnoreRightFilter]
        public ActionResult GetListWithPager(BaseFilter filters)
        {
            var result = _mapper.MapPageList<WxReplyDto, WxReply>(_wxReplyRepository.GetDataForListPager(filters));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region 单文本
        public ActionResult AddSingleTextReply()
        {
            return View(new TextReplyInfo());
        }

        [HttpPost]
        public ActionResult AddSingleTextReply(TextReplyInfo model)
        {
            if (ModelState.IsValid)
            {
                var isOK = RunWithCatch(r =>
                {
                    var key = model.Keys.Trim();
                    if (!string.IsNullOrEmpty(model.Keys) && _wxReplyRepository.Query().Any(x => x.Keys == key))
                    {
                        r.AddModelError("Keys", "关键字重复!");
                    }
                    else
                    {
                        WxReply info;
                        info = new WxReply();
                        info.MessageType = MessageType.Text;
                        info.IsDisabled = model.IsDisable;
                        if (model.ReplyType == ReplyType.Keys && !string.IsNullOrWhiteSpace(model.Keys))
                        {
                            info.Keys = model.Keys.Trim();
                        }
                        info.Content = model.Text.Trim();
                        info.MatchType = model.MatchType;
                        if (model.ReplyType == ReplyType.Keys)
                        {
                            info.ReplyType |= ReplyType.Keys;
                        }
                        if (model.ReplyType == ReplyType.Subscribe)
                        {
                            info.ReplyType |= ReplyType.Subscribe;
                        }
                        if (model.ReplyType == ReplyType.NoMatch)
                        {
                            info.ReplyType |= ReplyType.NoMatch;
                        }
                        if (info.ReplyType == ReplyType.None)
                        {
                            r.AddModelError("ReplyType", "请选择回复类型");
                        }
                        else if (_wxReplyRepository.Insert(info))
                        {
                            return true;
                        }
                        else
                        {
                            r.AddModelError("", new Exception("添加失败"));
                        }
                    }
                    return false;
                });

                if (isOK)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public ActionResult EditSingleTextReply(string id)
        {
            var entity = _wxReplyRepository.Get(x => x.Id == id);
            var model = new TextReplyInfo();
            model.ReplyType = entity.ReplyType;
            model.MatchType = entity.MatchType;
            model.IsDisable = entity.IsDisabled;
            model.Id = entity.Id;
            model.CreateDateTime = entity.CreateDateTime;
            model.Keys = entity.Keys;
            model.Text = entity.Content;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditSingleTextReply(TextReplyInfo model)
        {
            if (ModelState.IsValid)
            {
                var isOK = RunWithCatch(ms =>
            {
                var reply = _wxReplyRepository.Get(x => x.Id == model.Id);
                if ((!string.IsNullOrEmpty(model.Keys) && (reply.Keys != model.Keys.Trim())) && _svc.HasReplyKey(model.Keys.Trim()))
                {
                    ms.AddModelError("Keys", "关键字重复!");
                }
                else
                {
                    reply.IsDisabled = model.IsDisable;
                    if (model.ReplyType == ReplyType.Keys && !string.IsNullOrWhiteSpace(model.Keys))
                    {
                        reply.Keys = model.Keys.Trim();
                    }
                    else
                    {
                        reply.Keys = string.Empty;
                    }
                    reply.Content = model.Text;
                    reply.MatchType = model.MatchType;
                    reply.ReplyType = ReplyType.None;
                    if (model.ReplyType == ReplyType.Keys)
                    {
                        reply.ReplyType |= ReplyType.Keys;
                    }
                    if (model.ReplyType == ReplyType.Subscribe)
                    {
                        reply.ReplyType |= ReplyType.Subscribe;
                    }
                    if (model.ReplyType == ReplyType.NoMatch)
                    {
                        reply.ReplyType |= ReplyType.NoMatch;
                    }
                    if (model.ReplyType == ReplyType.None)
                    {
                        ms.AddModelError("ReplyType", "请选择回复类型");
                    }
                    else if (_wxReplyRepository.Update(reply, p => new object[] { reply.Id }))
                    {
                        return true;
                    }
                }

                return false;
            });

                if (isOK)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        #endregion

        #region 单图文
        public ActionResult AddSingleTextImageReply()
        {
            return View(new AddNewsMsgInfo());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSingleTextImageReply(AddNewsMsgInfo model)
        {
            if (ModelState.IsValid)
            {
                var isOk = RunWithCatch((r) =>
                {
                    var keys = model.Reply?.Keys;
                    if ((!string.IsNullOrEmpty(keys) && !string.IsNullOrEmpty(model.Description)) && !string.IsNullOrEmpty(model.PicUrl))
                    {
                        if (!string.IsNullOrEmpty(keys) && _wxReplyRepository.Query().Any(x => x.Keys == keys))
                        {
                            r.AddModelError("Keys", "关键字重复!");
                        }
                        else
                        {
                            WxReply reply = new WxReply()
                            {
                                IsDisabled = !model.Reply.IsDisable,
                            };

                            if (model.KeyReply && !string.IsNullOrWhiteSpace(keys))
                            {
                                reply.Keys = keys.Trim();
                            }
                            if (model.KeyReply && string.IsNullOrWhiteSpace(keys))
                            {
                                r.AddModelError("Reply.Keys", "你选择了关键字回复，必须填写关键字！");
                            }
                            else
                            {
                                reply.MatchType = model.Reply.MatchType;
                                reply.MessageType = MessageType.News;
                                if (model.KeyReply)
                                {
                                    reply.ReplyType |= ReplyType.Keys;
                                }
                                if (model.SubscribeReply)
                                {
                                    reply.ReplyType |= ReplyType.Subscribe;
                                }
                                if (model.NoMatchReply)
                                {
                                    reply.ReplyType |= ReplyType.NoMatch;
                                }
                                if (reply.ReplyType == ReplyType.None)
                                {
                                    r.AddModelError("Reply.ReplyType", "请选择回复类型");
                                }
                                else if (string.IsNullOrEmpty(model.Title))
                                {
                                    r.AddModelError("Title", "请输入标题");
                                }
                                else if (string.IsNullOrEmpty(model.PicUrl))
                                {
                                    r.AddModelError("PicUrl", "请上传封面图");
                                }
                                else if (string.IsNullOrEmpty(model.Content) && string.IsNullOrEmpty(model.Url))
                                {
                                    r.AddModelError("Url", "请输入内容或自定义链接");
                                }
                                else
                                {
                                    if (_wxReplyRepository.Insert(reply))
                                    {
                                        if (model.Reply == null)
                                        {
                                            model.Reply = new NewsReplyInfo() { Id = reply.Id };
                                        }

                                        model.Reply.Id = reply.Id;
                                        WxMessage item = _mapper.Map<WxMessage>(model);
                                        // insert messags 
                                        return _wxMsgRepository.Insert(item);
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }

                    return true;
                });

                if (isOk)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public ActionResult EditSingleTextImageReply(string id)
        {
            var reply = _svc.GetReply(id);
            var firstNews = _svc.GetNewsReplyInfo(reply.Id).FirstOrDefault();

            if (firstNews == null)
            {
                firstNews = new NewsMsgInfo();
            }

            AddNewsMsgInfo model = new AddNewsMsgInfo();
            model.Reply = _mapper.Map<NewsReplyInfo>(reply);

            model.Content = firstNews.Content;
            model.Description = firstNews.Description;
            model.Id = firstNews.Id;
            model.Title = firstNews.Title;
            model.Url = firstNews.Url;
            model.PicUrl = firstNews.PicUrl;

            // allow login reply 
            model.AllowSubscribeReply = getCanChangeSubscribeReply();
            model.AllowNoMatchReply = getCanChangeNoMatchReply();

            model.Setup();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditSingleTextImageReply(AddNewsMsgInfo model)
        {
            if (ModelState.IsValid)
            {
                var isOk = RunWithCatch((r) =>
                {
                    var keys = model.Reply?.Keys;
                    if ((!string.IsNullOrEmpty(keys) && !string.IsNullOrEmpty(model.Description)) && !string.IsNullOrEmpty(model.PicUrl))
                    {
                        if (!string.IsNullOrEmpty(keys) && _wxReplyRepository.Query().Any(x => x.Id != model.Id && x.Keys == keys))
                        {
                            r.AddModelError("Keys", "关键字重复!");
                        }
                        else
                        {
                            WxReply reply = _wxReplyRepository.Get(x => x.Id == model.Id);

                            if (model.KeyReply && !string.IsNullOrWhiteSpace(keys))
                            {
                                reply.Keys = keys.Trim();
                            }
                            if (model.KeyReply && string.IsNullOrWhiteSpace(keys))
                            {
                                r.AddModelError("Reply.Keys", "你选择了关键字回复，必须填写关键字！");
                            }
                            else
                            {
                                reply.MatchType = model.Reply.MatchType;
                                reply.MessageType = MessageType.News;
                                if (model.KeyReply)
                                {
                                    reply.ReplyType |= ReplyType.Keys;
                                }
                                if (model.SubscribeReply)
                                {
                                    reply.ReplyType |= ReplyType.Subscribe;
                                }
                                if (model.NoMatchReply)
                                {
                                    reply.ReplyType |= ReplyType.NoMatch;
                                }

                                if (!model.SubscribeReply
                                    && !model.NoMatchReply
                                    && !model.KeyReply)
                                {
                                    reply.ReplyType = ReplyType.None;
                                }

                                if (reply.ReplyType == ReplyType.None)
                                {
                                    r.AddModelError("Reply.ReplyType", "请选择回复类型");
                                }
                                else if (string.IsNullOrEmpty(model.Title))
                                {
                                    r.AddModelError("Title", "请输入标题");
                                }
                                else if (string.IsNullOrEmpty(model.PicUrl))
                                {
                                    r.AddModelError("PicUrl", "请上传封面图");
                                }
                                else if (string.IsNullOrEmpty(model.Content) && string.IsNullOrEmpty(model.Url))
                                {
                                    r.AddModelError("Url", "请输入内容或自定义链接");
                                }
                                else
                                {
                                    if (_wxReplyRepository.Update(reply, (b) => new object[] { reply.Id }))
                                    {
                                        WxMessage item = _wxMsgRepository.Get(x => x.ReplyId == reply.Id);
                                        item.Title = model.Title;
                                        item.Url = model.Url;
                                        item.ImageUrl = model.PicUrl;
                                        item.Content = model.Content;
                                        item.Description = model.Description;

                                        // insert messags 
                                        return _wxMsgRepository.Update(item, e => new object[] { item.Id });
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }

                    return false;
                });

                if (isOk)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        private bool getCanChangeSubscribeReply()
        {
            return !_wxReplyRepository.Query().Any(x => x.ReplyType == ReplyType.Subscribe);
        }

        private bool getCanChangeNoMatchReply()
        {
            return !_wxReplyRepository.Query().Any(x => x.ReplyType == ReplyType.NoMatch);
        }

        #endregion
    }
}