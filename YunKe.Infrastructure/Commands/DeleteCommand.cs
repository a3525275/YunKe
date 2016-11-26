using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Data;

namespace YunKe.Infrastructure.Commands
{
    public class DeleteCommand<T> : ICommand where T : IBaseEntity
    {
        public string Id { get; set; }

        public string[] Ids { get; set; }
    }
}
