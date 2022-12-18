using Cache.App.Service.Services;
using Cache.App.Service.Services.Interfaces;
using Cache.Core.Extensions;
using Cache.Redis.Extensions;

namespace Cache.App.Service.Extensions
{
    public static class DependencyResolverExtensions
    {
        public static void AddDependencyResolvers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedis(configuration, "RedisSettings");
            services.AddProxiedScoped<IPersonelService, PersonelService>();
        }
    }
}
