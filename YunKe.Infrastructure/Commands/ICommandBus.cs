using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Commands
{
    public interface ICommandBus
    {
        CommandResult Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
