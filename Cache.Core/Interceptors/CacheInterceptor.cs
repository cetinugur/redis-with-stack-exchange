using Cache.Core.Attributes;
using Cache.Core.Interfaces;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using System.Text.Json;

namespace Cache.Core.Interceptors
{
    public class CacheInterceptor : IInterceptor
    {
        private readonly ICacheProvider cacheProvider;
        private readonly object lockObject = new object();
        public CacheInterceptor(ICacheProvider cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;
            method ??= invocation.Method;

            var cacheAttribute = method.GetAttribute<CacheAttribute>();

            if (cacheAttribute is null)
            { 
                invocation.Proceed();
                return;
            }

            lock (lockObject)
            {
                string cacheKey = string.Empty;

                string cacheGroup = invocation.TargetType.Name + ":";

                if (cacheAttribute.CachePreferences.CacheKeyPrefix is not null)
                {
                    cacheKey = $"{cacheAttribute.CachePreferences.CacheKeyPrefix}_";
                }

                cacheKey = $"{cacheGroup}{cacheKey}{method.Name}_{string.Join("_", invocation.Arguments)}";

                bool cacheExist = cacheProvider.IsCacheExist(cacheKey);
                if (cacheExist)
                {
                    invocation.ReturnValue = JsonSerializer.Deserialize(cacheProvider.Get(cacheKey),method.ReturnType);
                }
                else
                {
                    invocation.Proceed();
                    var returnValue = invocation.ReturnValue;
                    if (returnValue is not null)
                    { 
                        cacheProvider.SetAsync(cacheKey, returnValue,cacheAttribute.CachePreferences.DurationInTimespan);
                    }
                }
            }
        }
    }
}
