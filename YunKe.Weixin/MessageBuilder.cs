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
    public class MessageBuilder : IMessageBuilder
    {
        private readonly IMapper _mapper;
        private readonly IRepository<WxMessage> _Repo;

        public MessageBuilder(IRepository<WxMessage> repo,
            IMapper mapper)
        {
            _Repo = repo;
            _mapper = mapper;
        }

        public string Build(WxMessage template, object data)
        {
            return template.Content;
        }
    }
}
