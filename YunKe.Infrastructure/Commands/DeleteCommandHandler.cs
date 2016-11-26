using System.Linq;
using YunKe.Infrastructure.Data;
using YunKe.Infrastructure.Service;

namespace YunKe.Infrastructure.Commands
{
    public class DeleteCommandHandler<T> :
          ICommandHandler<DeleteCommand<T>> where T : class, IBaseEntity, new()
    {
        private readonly IRepository<T> _repo;

        public DeleteCommandHandler(IRepository<T> repo)
        {
            _repo = repo;
        }

        public CommandResult Handle(DeleteCommand<T> command)
        {
            if (command.Ids != null && command.Ids.Any())
            {
                return _repo.DeleteBatch(p => command.Ids.Contains(p.Id));
            }
            else
            {
                return _repo.DeleteBatch(p => command.Id == p.Id);
            }
        }
    }
}
