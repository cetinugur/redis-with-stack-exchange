using Cache.Core.Interfaces;
using StackExchange.Redis;

namespace Cache.Redis.Concretes
{
    public class RedisCacheProvider : ICacheProvider
    {
        public RedisCacheProvider(RedisCacheProviderOptions options, ConnectionMultiplexer redis)
        {

        }
    }
}
