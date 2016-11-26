using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Commands;

namespace YunKe.Commerce.Customers.Commands
{
    public class CustomersCommandHandler : ICommandHandler<CreateCustomersCommand>
    {
        public CustomersCommandHandler() {

        }

        public CommandResult Handle(CreateCustomersCommand command)
        {
            return new CommandResult();
        }
    }
}
