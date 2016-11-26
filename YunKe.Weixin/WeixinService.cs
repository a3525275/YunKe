using YunKe.Weixin.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Weixin.Entity;
using YunKe.Weixin.Dtos;
using YunKe.Weixin.Models; 
using AutoMapper;
using Hishop.Weixin.MP.Domain.Menu;
using Newtonsoft.Json;
using Hishop.Weixin.MP.Api;
using Hishop.Weixin.MP.Domain;
using YunKe.Infrastructure.Service;

namespace YunKe.Weixin
{
    public class WeixinService : IWeixinService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<WxMenu> _menuRepo;
        private readonly IRepository<WxMessage> _msgRepo;
        private readonly IRepository<WxReply> _replyRepo;
        private readonly IRepository<WxTopic> _topicRepo;
        private readonly IRepository<WxOfficalAccount> _offcicalAccountRepo;

        public WeixinService(IRepository<WxMenu> menuRepo,
            IRepository<WxReply> replyRepo,
            IRepository<WxTopic> topicRepo,
            IRepository<WxMessage> msgRepo,
            IRepository<WxOfficalAccount> offcicalAccountRepo,
            IMapper mapper)
        {
            _menuRepo = menuRepo;
            _replyRepo = replyRepo;
            _topicRepo = topicRepo;
            _msgRepo = msgRepo;
            _offcicalAccountRepo = offcicalAccountRepo;
            _mapper = mapper;
        }

        public WxMenuDto GetMenu(string menuId)
        {
            var menu = _menuRepo.Get(p => p.Id == menuId);
            return _mapper.Map<WxMenu, WxMenuDto>(menu);
        }

        public ReplyInfo GetMismatchReply()
        {
            var replies = GetReplies(ReplyType.NoMatch);

            if ((replies != null) && (replies.Count > 0))
            {
                return replies[0];
            }
            return null;
        }

        public IList<ReplyInfo> GetReplies(ReplyType type)
        {
            var replies = _replyRepo.Query().Where(x => x.ReplyType == type).ToList();

            List<ReplyInfo> list = new List<ReplyInfo>();
            foreach (var p in replies)
            {
                TextReplyInfo info3;
                WxReply info = p;
                switch (info.MessageType)
                {
                    default:
                    case MessageType.Text:
                        info3 = new TextReplyInfo()
                        {
                            ActivityId = p.ActivityId,
                            Id = p.Id,
                            Text = p.Content,
                            IsDisable = p.IsDisabled,
                            Keys = p.Keys,
                            LastEditDate = p.LastModified,
                            LastEditor = p.LastModifier,
                            MatchType = p.MatchType,
                            MessageType = p.MessageType,
                            ReplyType = p.ReplyType,
                        };
                        list.Add(info3);
                        break;

                    case MessageType.News:
                    case MessageType.List:
                        {
                            NewsReplyInfo item = new Models.NewsReplyInfo()
                            {
                                ActivityId = p.ActivityId,
                                Id = p.Id,
                                IsDisable = p.IsDisabled,
                                Keys = p.Keys,
                                LastEditDate = p.LastModified,
                                LastEditor = p.LastModifier,
                                MatchType = p.MatchType,
                                MessageType = p.MessageType,
                                ReplyType = p.ReplyType,
                            };

                            item.NewsMsg = this.GetNewsReplyInfo(item.Id);
                            list.Add(item);
                            break;
                        }
                }
            }

            return list;
        }

        public IList<NewsMsgInfo> GetNewsReplyInfo(string id)
        {
            return _msgRepo.Query(p => p.ReplyId == id)
                     .Select(p => new NewsMsgInfo()
                     {
                         Content = p.Content,
                         Description = p.Description,
                         Id = p.Id,
                         PicUrl = p.ImageUrl,
                         Title = p.Title,
                         Url = p.Url,
                     }).ToList();
        }

        public ReplyInfo GetReply(string replyId)
        {
            var res = _replyRepo.Query().Where(x => x.Id == replyId).Select(p => new ReplyInfo
            {
                ActivityId = p.ActivityId,
                Id = p.Id,
                IsDisable = p.IsDisabled,
                Keys = p.Keys,
                LastEditDate = p.LastModified,
                LastEditor = p.LastModifier,
                MatchType = p.MatchType,
                MessageType = p.MessageType,
                ReplyType = p.ReplyType,
            }).FirstOrDefault();

            return res;
        }

        public ReplyInfo GetSubscribeReply()
        {
            IList<ReplyInfo> replies = GetReplies(ReplyType.Subscribe);
            if ((replies != null) && (replies.Count > 0))
            {
                return replies[0];
            }
            return null;
        }

        public WxTopicDto Gettopic(string topicId)
        {
            var topic = _topicRepo.Get(x => x.Id == topicId);

            if (topic == null)
            {
                return null;
            }

            return _mapper.Map<WxTopicDto>(topic);

        }

        /// <summary>
        /// 发布微信菜单到微信公众号服务器。
        /// </summary>
        /// <returns></returns>
        public PublishWxMenuResponse PublishMenus()
        {
            var resp = new PublishWxMenuResponse();
            IList<WxMenuDto> initMenus = this.GetInitMenus(MenuClient.Weixin);
            Menu menu = new Menu();
            foreach (var info in initMenus.OrderBy(p => p.Sequence))
            {
                if ((info.Chilren == null) || (info.Chilren.Count == 0))
                {
                    menu.menu.button.Add(this.BuildMenu(info));
                    continue;
                }
                SubMenu item = new SubMenu
                {
                    name = info.Name
                };
                foreach (var info2 in info.Chilren.OrderBy(x => x.Sequence))
                {
                    item.sub_button.Add(this.BuildMenu(info2));
                }
                menu.menu.button.Add(item);
            }
            string json = JsonConvert.SerializeObject(menu.menu);
            var masterSettings = GetOfficalAccount();
            if (string.IsNullOrEmpty(masterSettings.AppId) || string.IsNullOrEmpty(masterSettings.AppSecret))
            {
                resp.AddMessage("您的服务号配置存在问题，请您先检查配置！").SetSuccess(false);
            }
            else
            {
                string token = TokenApi.GetToken(masterSettings.AppId, masterSettings.AppSecret);
                try
                {
                    token = (JsonConvert.DeserializeObject(token, typeof(Token)) as Token).access_token;
                    if (MenuApi.CreateMenus(token, json).Contains("ok"))
                    {
                        resp.AddMessage("成功的把自定义菜单保存到了微信").SetSuccess(true);
                    }
                    else
                    {
                        resp.AddMessage("操作失败!服务号配置信息错误或没有微信自定义菜单权限，请检查配置信息以及菜单的长度。")
                            .SetSuccess(false);
                    }
                }
                catch (Exception exception)
                {
                    resp.AddMessage(exception.Message + "---" + token + "---" + masterSettings.AppId + "---" + masterSettings.AppSecret)
                        .SetSuccess(false).Error = exception;
                }
            }

            return resp;
        }

        private WxOfficalAccount GetOfficalAccount(string id = null)
        {
            WxOfficalAccount account = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                account = _offcicalAccountRepo.Query().FirstOrDefault(x => x.Id == id);
            }
            else
            {
                account = _offcicalAccountRepo.Query().FirstOrDefault();
            }
            return account;
        }

        private SingleButton BuildMenu(WxMenuDto menu)
        {
            switch (menu.BindType)
            {
                case BindType.Key:
                    return new SingleClickButton { name = menu.Name, key = menu.Id.ToString() };

                case BindType.Topic:
                case BindType.HomePage:
                case BindType.Url:
                    return new SingleViewButton { name = menu.Name, url = menu.Url };
            }
            return new SingleClickButton { name = menu.Name, key = "None" };
        }

        private IList<WxMenuDto> GetInitMenus(MenuClient clientType)
        {
            IList<WxMenuDto> topMenus = this.GetTopMenus(clientType).ToList();
            foreach (var info in topMenus)
            {
                info.Chilren = this.GetMenusByParentId(info.Id, clientType).ToList();
                if (info.Chilren == null)
                {
                    info.Chilren = new List<WxMenuDto>();
                }
            }
            return topMenus;
        }

        private IEnumerable<WxMenuDto> GetMenusByParentId(string menuId, MenuClient clientType)
        {
            var menus = _menuRepo.Query(p => p.ParentId == menuId && p.Client == clientType).ToList();

            foreach (var menu in menus)
            {
                yield return _mapper.Map<WxMenuDto>(menu);
            }
        }

        private IEnumerable<WxMenuDto> GetTopMenus(MenuClient clientType)
        {
            return GetMenusByParentId(null, clientType);
        }

        public bool HasReplyKey(string key)
        {
            return _replyRepo.Query().Any(p => p.Keys == key);
        }

        public void SendNotification(SendNotificationModel model)
        {
            TemplateApi.SendMessage(model.AccessToken, new TemplateMessage()
            {
                Url = model.Url,
                Data = model.Data,
                TemplateId = model.TemplateId,
                Topcolor = model.TopColor,
                Touser = model.OpenIdSendTo,
            });
        }

        public WxOfficalAccount GetWxAccountByName(string name = "Default")
        {
            return GetOfficalAccount("");
        }
    }
}
