using Cache.Core.Extensions;
using Cache.Imp.Services;
using Cache.Imp.Services.Interfaces;

namespace Cache.Imp.Extensions
{
    public static class DependencyResolverExtensions
    {
        public static void AddDependencyResolvers(this IServiceCollection services)
        {
            services.CacheCore();
            services.AddProxiedScoped<IPersonelService, PersonelService>();
        }
    }
}
