using ServiceStack.Redis;
using YunKe.Infrastructure.Caching;

namespace YunKe.Infrastructure.RedisCacheProvider
{
    public class RedisCacheService : ICacheProvider
    {
        public RedisCacheService()
        {
        }

        public TResult Get<TResult>(string key)
        {
            using (IRedisClient _client = RedisCacheManager.Instance.GetClient())
            {
                return _client.Get<TResult>(key);
            }
        }

        public void Set(string key, object value)
        {
            using (IRedisClient _client = RedisCacheManager.Instance.GetClient())
            {
                _client.Set(key, value);
            }
        }
    }
}
