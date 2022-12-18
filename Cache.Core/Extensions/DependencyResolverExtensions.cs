using Cache.Core.Interceptors;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Cache.Core.Extensions
{
    public static class DependencyResolverExtensions
    {
        public static IServiceCollection AddCacheCore(this IServiceCollection services)
        {
            services.AddScoped<IInterceptor, CacheInterceptor>();
            services.AddSingleton(new ProxyGenerator());
            return services;
        }

        public static void AddProxiedScoped<TInterface, TImplementation>(this IServiceCollection services) where TInterface : class where TImplementation : class, TInterface
        {
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }
    }
}
