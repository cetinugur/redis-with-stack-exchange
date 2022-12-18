using Cache.Core.Abstracts;
using StackExchange.Redis;

namespace Cache.Redis.Concretes
{
    public class RedisCacheProviderOptions : CacheProviderOptions
    {
        public ConfigurationOptions GetConfiguration
        {
            get
            {
                string url = $"{Host}:{Port}";
                string config = $"{url},ssl={HasSSL}"
                                    + $",AbortOnConnectFail:{false}"
                                    + $",password:{Password}"
                                    + $",ConnectTimeout:{ConnectTimeout}"
                                    + $",ResponseTimeout:{ConnectTimeout}"
                                    + $",DefaultDatabase:{DatabaseId}"
                                    + $",AllowAdmin:{false}"
                                    + $",ConnectRetry:{ConnectTry}"
                                    + $",SyncTimeout:{ConnectTimeout}"
                                    + $",AsyncTimeout:{ConnectTimeout}"
                                    + $",keepAlive:{3600}";

                return ConfigurationOptions.Parse(config);
            }
        }
    }
}
