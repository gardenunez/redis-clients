using System;
using RedisClient.Clients;
using ServiceStack.Redis;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace RedisClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string host = "redis-host:6379";
            IRedisClientsManager manager = new BasicRedisClientManager(host){
                ConnectTimeout = 100
            };
            ICacheManager cacheManager = new ServiceStackRedisCacheManager(manager);
            PlayKeyValue(cacheManager);


            var serializer = new NewtonsoftSerializer();
            ICacheManager seCacheManager = new StackExchangeRedisCacheManager(serializer);
            PlayKeyValue(cacheManager);


            Console.WriteLine("END");
            Console.Read();
        }

        static void PlayKeyValue(ICacheManager cacheManager)
        {
            int tick = System.Environment.TickCount;
            string key = "hello " + tick;
            string value = "world!! " + tick;
            cacheManager.Add(key, value, TimeSpan.FromSeconds(5));
            Console.WriteLine(cacheManager.Get<string>(key));
        }
    }
}
