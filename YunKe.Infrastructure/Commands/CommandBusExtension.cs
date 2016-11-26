using System.Linq;
using YunKe.Infrastructure.Data;

namespace YunKe.Infrastructure.Commands
{
    public static class CommandBusExtension
    {
        /// <summary>
        /// Sends the delete command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bus">The bus.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public static CommandResult SendDeleteCommand<T>(this ICommandBus bus, params string[] ids) where T : class, IBaseEntity
        {
            return bus.Send(new DeleteCommand<T>() { Ids = ids, Id = ids.FirstOrDefault() });
        }
    }
}
