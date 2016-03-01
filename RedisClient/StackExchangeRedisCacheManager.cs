using System;

namespace RedisClient
{
    public class StackExchangeRedisCacheManager : ICacheManager, IRedisCacheManager
    {

        public StackExchangeRedisCacheManager()
        {
        }

        public bool Add<TItem>(string key, TItem item, TimeSpan expirationPeriod)
        {
            throw new NotImplementedException();
        }

        public TItem Get<TItem>(string key)
        {
            throw new NotImplementedException();
        }
    }
}
