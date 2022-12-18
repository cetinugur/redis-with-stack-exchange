using Cache.Core.Interfaces;
using Castle.DynamicProxy;

namespace Cache.Core.Interceptors
{
    public class CacheInterceptor : IInterceptor
    {
        private readonly ICacheProvider cacheProvider;

        public CacheInterceptor(ICacheProvider cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;
            method ??= invocation.Method;

            invocation.Proceed();
        }
    }
}
