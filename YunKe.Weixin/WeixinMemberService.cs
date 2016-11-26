using AutoMapper;
using YunKe.Weixin.Entity;
using YunKe.Weixin.Contracts;
using YunKe.Weixin.Dtos;
using YunKe.Infrastructure.Service;
using System;

namespace YunKe.Weixin
{
    public class WeixinMemberService : IWeixinMemberService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<WxMember> _Repo;

        public WeixinMemberService(IRepository<WxMember> repo,
            IMapper mapper)
        {
            _Repo = repo;
            _mapper = mapper;
        }

        public bool AddMember(WxMemberDto dto)
        {
            var entity = _mapper.Map<WxMember>(dto);
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            entity.CreateDateTime = DateTime.Now;

            return _Repo.Insert(entity);
        }

        public bool DeleteMember(string openId)
        {
            return _Repo.DeleteBatch(p => p.OpenId == openId);
        }

        public WxMemberDto GetMemberByOpenId(string openId)
        {
            var entity = _Repo.Get(p => p.OpenId == openId);

            return _mapper.Map<WxMemberDto>(entity);
        }

        public bool UpdateMember(WxMemberDto dto)
        {
            var entity = _Repo.Get(p => p.OpenId == dto.OpenId);

            if (entity == null)
                return false;
            return update(entity, dto);
        }

        private bool update(WxMember entity, WxMemberDto dto)
        {
            entity.NickName = dto.NickName;
            entity.Icon = dto.Icon;
            entity.Birthday = dto.Birthday;
            entity.LastLoginDate = DateTime.Now;
            entity.SubscribedDate = dto.SubscribedDate;
            entity.Language = dto.Language;
            entity.OpenId = dto.OpenId;
            entity.Province = dto.Province;
            entity.City = dto.City;
            entity.Sex = dto.Sex;
            entity.Country = dto.Country;

            return _Repo.Update(entity, p => new object[] { entity.Id });
        }

        public bool AddOrUpdate(WxMemberDto dto)
        {
            var existing = _Repo.Get(p => p.OpenId == dto.OpenId);
            if (existing == null)
            {
                return AddMember(dto);
            }
            else
            {
                dto.Id = existing.Id;
                return update(existing, dto);
            }
        }
    }
}
