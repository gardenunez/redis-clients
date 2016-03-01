using System;
using ServiceStack.Redis;

namespace RedisClient.Clients
{
    public class ServiceStackRedisCacheManager : ICacheManager, IRedisCacheManager
    {
        private readonly IRedisClientsManager _redisClientsManager;

        public ServiceStackRedisCacheManager(IRedisClientsManager redisClientsManager)
        {
            _redisClientsManager = redisClientsManager;
        }

        public bool Add<TItem>(string key, TItem item, TimeSpan expirationPeriod)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            using (IRedisClient redisClient = _redisClientsManager.GetClient())
            {
                return redisClient.Add<TItem>(key, item, expirationPeriod);
            }
        }

        public TItem Get<TItem>(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            using (IRedisClient redisClient = _redisClientsManager.GetClient())
            {
                return redisClient.Get<TItem>(key);
            }
        }
    }
}
