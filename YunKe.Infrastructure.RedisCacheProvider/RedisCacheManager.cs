using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.RedisCacheProvider
{
    public class RedisCacheManager
    {
        private PooledRedisClientManager _pcm;

        private string conn = "";
        public RedisCacheManager()
        {
            conn = ConfigurationManager.ConnectionStrings["RedisConnection"].ConnectionString;
        }

        public IRedisClient GetClient()
        {
            if (_pcm == null)
            {
                _pcm = new PooledRedisClientManager(conn);
            }

            return _pcm.GetClient();
        }

        private static readonly object _lockObject = new object();

        private static RedisCacheManager _instance;
        public static RedisCacheManager Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        lock (_lockObject)
                        {
                            _instance = new RedisCacheManager();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
