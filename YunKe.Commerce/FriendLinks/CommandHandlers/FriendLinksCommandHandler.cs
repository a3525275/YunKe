using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.Commerce.FriendLinks.Commands;
using YunKe.Infrastructure.Commands;
using YunKe.Infrastructure.Service;

namespace YunKe.Commerce.FriendLinks.CommandHandlers
{
    public class FriendLinksCommandHandler :
            DeleteCommandHandler<FriendLink>,
            ICommandHandler<Commands.CreateFriendLinkCommand>,
            ICommandHandler<Commands.UpdateFriendLinkCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FriendLink> _repo;

        public FriendLinksCommandHandler(IRepository<FriendLink> repo, IMapper mapper)
            : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public CommandResult Handle(CreateFriendLinkCommand command)
        {
            var entity = _mapper.Map<FriendLink>(command);

            return _repo.Insert(entity);
        }

        public CommandResult Handle(UpdateFriendLinkCommand command)
        {
            var entity = _repo.Get(x => x.Id == command.Id);

            _mapper.Map(command, entity);

            return _repo.Update(entity, r => new object[] { entity.Id });
        }
    }
}
