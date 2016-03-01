using System;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;

namespace RedisClient.Clients
{
    public class StackExchangeRedisCacheManager : ICacheManager, IRedisCacheManager
    {
        private readonly ISerializer _serializer;

        public StackExchangeRedisCacheManager(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public bool Add<TItem>(string key, TItem item, TimeSpan expirationPeriod)
        {
            using (var cacheClient = new StackExchangeRedisCacheClient(_serializer))
            {
                return cacheClient.Add(key, item, expirationPeriod);
            }
        }

        public TItem Get<TItem>(string key)
        {
            using (var cacheClient = new StackExchangeRedisCacheClient(_serializer))
            {
                return cacheClient.Get<TItem>(key);
            }
        }
    }
}
