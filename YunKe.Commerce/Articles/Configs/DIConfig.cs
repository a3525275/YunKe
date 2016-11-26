using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Commerce.Articles.Commands;
using YunKe.Infrastructure.Commands;

namespace YunKe.Commerce.Articles.Configs
{
    public class DIConfig
    {
        public static void Register(Container container)
        {
            container.Register<ICommandHandler<CreateArticleCommand>, ArticlesCommandHandler>();
        }
    }
}
