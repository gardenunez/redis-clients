using System;
using ServiceStack.Redis;

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
            int tick = System.Environment.TickCount;
            string key = "hello " + tick;
            string value = "world!! " + tick;
            cacheManager.Add(key, value, TimeSpan.FromSeconds(5));
            Console.WriteLine(cacheManager.Get<string>(key));

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
