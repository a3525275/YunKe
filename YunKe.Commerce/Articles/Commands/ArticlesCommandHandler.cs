using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Commands;

namespace YunKe.Commerce.Articles.Commands
{
    public class ArticlesCommandHandler :
        ICommandHandler<CreateArticleCommand>
    {
        public ArticlesCommandHandler()
        {

        }

        public CommandResult Handle(CreateArticleCommand command)
        {
            return new CommandResult();
        }
    }
}
