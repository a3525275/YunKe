using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Caching
{
    public interface ICacheProvider
    {
        TResult Get<TResult>(string key);

        void Set(string key, object value);
    }
}
