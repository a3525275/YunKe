using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        CommandResult Handle(TCommand command);
    }
}
