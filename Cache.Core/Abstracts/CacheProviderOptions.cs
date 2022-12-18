namespace Cache.Core.Abstracts
{
    public abstract class CacheProviderOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int DatabaseId { get; set; } = 0;
        public string Password { get; set; }
        public bool HasSSL { get; set; } = false;
        public int ConnectTimeout { get; set; } = 30;
        public int ConnectTry { get; set; } = 3;
    }
}
