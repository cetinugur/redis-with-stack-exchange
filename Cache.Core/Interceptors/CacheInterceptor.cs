using Castle.DynamicProxy;

namespace Cache.Core.Interceptors
{
    public class CacheInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;
            method ??= invocation.Method;

            invocation.Proceed();
        }
    }
}
