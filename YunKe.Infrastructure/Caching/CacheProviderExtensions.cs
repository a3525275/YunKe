using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Caching
{
    public static class CacheProviderExtensions
    {
        /// <summary>
        /// Gets or sets the cached object.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="cacher"></param>
        /// <param name="key"></param>
        /// <param name="getter"></param>
        /// <returns></returns>
        public static TResult GetOrSet<TResult>(this ICacheProvider cacher, string key, Func<TResult> getter = null)
        {
            var result = cacher.Get<TResult>(key);
            if (result == null && getter != null)
            {
                result = getter();
                if (result != null)
                {
                    cacher.Set(key, result);
                }
            }

            return result;
        }
    }
}
