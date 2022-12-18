using Cache.Core.Extensions;
using Cache.Core.Interfaces;
using Cache.Redis.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Cache.Redis.Extensions
{
    public static class DependencyResolverExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration, string cacheSettingsFieldName)
        {
            services.AddCacheCore();

            var options = configuration.GetSection(cacheSettingsFieldName).Get<RedisCacheProviderOptions>();

            var redis = ConnectionMultiplexer.Connect(options.GetConfiguration);
            services.AddSingleton<IConnectionMultiplexer>(redis);
            services.AddSingleton<ICacheProvider>(x => new RedisCacheProvider(options, redis));

            return services;
        }
    }
}
