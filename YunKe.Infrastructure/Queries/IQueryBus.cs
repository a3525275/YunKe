using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Queries
{
    public interface IQueryBus
    {
        TResult Send<TQuery, TResult>(TQuery query);
    }
}
