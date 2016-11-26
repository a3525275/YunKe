using System.Linq;
using AutoMapper;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Extentions;
using SimpleInjector;
using YunKe.Weixin.Dtos;
using YunKe.Weixin.Contracts;
using YunKe.Weixin.Models;
using System;
using YunKe.Weixin.Entity;
using YunKe.Infrastructure.Service;

namespace YunKe.Weixin
{
    /// <summary>
    /// 模块初始化
    /// </summary>
    public class WxModuleInitializer : ModuleInitializer
    {
        /// <summary>
        /// 加载SimpleInject配置
        /// </summary>
        /// <param name="container"></param>
        public override void LoadIoc(Container container)
        {
            container.Register<IWeixinService, WeixinService>(Lifestyle.Scoped);
            container.Register<IWeixinMemberService, WeixinMemberService>(Lifestyle.Scoped);
            container.Register<IMessageBuilder, MessageBuilder>(Lifestyle.Scoped);

            //container.Register<IRepository<WxMenu>, RepositoryBase<WxMenu>>(Lifestyle.Scoped);
            //container.Register<IRepository<WxTopic>, RepositoryBase<WxTopic>>(Lifestyle.Scoped);
            //container.Register<IRepository<WxMessage>, RepositoryBase<WxMessage>>(Lifestyle.Scoped);
            //container.Register<IRepository<WxReply>, RepositoryBase<WxReply>>(Lifestyle.Scoped);
            //container.Register<IRepository<WxOfficalAccount>, RepositoryBase<WxOfficalAccount>>(Lifestyle.Scoped);
            //container.Register<IRepository<WxMember>, RepositoryBase<WxMember>>(Lifestyle.Scoped);
            //container.Register<IRepository<WxSiteMenu>, RepositoryBase<WxSiteMenu>>(Lifestyle.Scoped);
        }

        /// <summary>
        /// 加载AutoMapper配置
        /// </summary>
        /// <param name="config"></param>
        public override void LoadAutoMapper(IMapperConfiguration config)
        {
            config.CreateMap<WxMenu, WxMenuDto>().ReverseMap();
            config.CreateMap<WxMessage, WxMessageDto>().ReverseMap();
            config.CreateMap<WxTopic, WxTopicDto>().ReverseMap();
            config.CreateMap<WxReply, WxReplyDto>().ReverseMap();
            config.CreateMap<WxSiteMenu, WxSiteMenuDto>().ReverseMap();

            config.CreateMap<WxMember, WxMemberDto>().ReverseMap();

            config.CreateMap<NewsMsgInfo, WxMessage>().ProjectUsing((from) => new WxMessage()
            {
                Content = from.Content,
                CreateDateTime = DateTime.Now,
                Description = from.Description,
                Id = Guid.NewGuid().ToString(),
                ImageUrl = from.PicUrl,
                ReplyId = from.Reply.Id,
                Title = from.Title,
                Url = from.Url,
            });

            config.CreateMap<NewsReplyInfo, ReplyInfo>().ReverseMap();

        }
    }
}
