using AutoMapper;
using System.Web.Mvc;
using YunKe.AdminPanelCore.Entity;
using YunKe.AdminPanelCore.Models;
using YunKe.Commerce.FriendLinks.Commands;
using YunKe.Commerce.FriendLinks.Queries;
using YunKe.Infrastructure.Commands;
using YunKe.Infrastructure.Queries;
using YunKe.Infrastructure.Service;

namespace YunKe.AdminPanel.Controllers
{
    public class FriendLinksController : CommonCRUDControllerBase<FriendLink,
        CreateFriendLinkCommand,
        UpdateFriendLinkCommand,
        FriendLinkDto, GetFriendLinksQuery>
    {
        public override ActionResult GetListWithPager(GetFriendLinksQuery filters)
        {
            filters.KeywordsField = "Text";
            return base.GetListWithPager(filters);
        }

    }
}