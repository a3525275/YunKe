using SimpleInjector;
using YunKe.AdminPanelCore.Entity;
using YunKe.AdminPanelCore.Models;
using YunKe.Commerce.FriendLinks.Commands;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Commands;
using YunKe.Infrastructure.Queries;

namespace YunKe.Commerce.FriendLinks.Configs
{
    public class FriendLinksDIConfig
    {
        public static void Register(Container container)
        {
            container.Register<ICommandHandler<CreateFriendLinkCommand>, CommandHandlers.FriendLinksCommandHandler>();

            container.Register<ICommandHandler<UpdateFriendLinkCommand>, CommandHandlers.FriendLinksCommandHandler>();

            container.Register<ICommandHandler<DeleteCommand<FriendLink>>, CommandHandlers.FriendLinksCommandHandler>();

            container.Register<IQueryHandler<Queries.GetFriendLinksQuery, PagedResult<FriendLinkDto>>, QueryHandlers.FriendLinksQueryHandler>();
        }
    }
}
