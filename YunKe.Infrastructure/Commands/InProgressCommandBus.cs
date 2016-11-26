using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Commands
{
    public class InProgressCommandBus : ICommandBus
    {
        private readonly Container _conponentContext;

        public InProgressCommandBus(Container container)
        {
            _conponentContext = container;
        }

        public CommandResult Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _conponentContext.GetInstance<ICommandHandler<TCommand>>();
            return handler.Handle(command);
        }
    }
}
