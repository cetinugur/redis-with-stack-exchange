namespace Cache.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CacheAttribute : Attribute
    {
    }
}
