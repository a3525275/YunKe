using System;
using AutoMapper;
using SimpleInjector;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.FriendLinks.Commands;
using YunKe.Infrastructure.Commands;
using YunKe.AdminPanelCore.Models;

namespace YunKe.Commerce.FriendLinks.Configs
{
    public class FriendLinksAutoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreateFriendLinkCommand, FriendLink>();
            CreateMap<FriendLink, FriendLinkDto>().ReverseMap();

            CreateMap<UpdateFriendLinkCommand, FriendLink>();
        }
    }
}
