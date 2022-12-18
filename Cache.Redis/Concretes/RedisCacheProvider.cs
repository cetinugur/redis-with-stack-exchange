using Cache.Core.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Cache.Redis.Concretes
{
    public class RedisCacheProvider : ICacheProvider
    {
        #region local fields
        protected readonly ConnectionMultiplexer connectionMultiplexer;
        protected readonly RedisCacheProviderOptions providerOptions;
        protected readonly IDatabase database;
        protected readonly IServer server;
        protected readonly double maxTTL;

        #endregion local fields
        public RedisCacheProvider(RedisCacheProviderOptions options, ConnectionMultiplexer connectionMultiplexer)
        {
            this.maxTTL = TimeSpan.MaxValue.TotalMilliseconds;
            this.providerOptions = options;
            this.connectionMultiplexer = connectionMultiplexer;
            this.server = connectionMultiplexer.GetServer(options.Host, options.Port);
            this.database = connectionMultiplexer.GetDatabase(options.DatabaseId);
        }

        public bool IsAnyIndexExist(string keyPattern)
        {
            return server.Keys(providerOptions.DatabaseId, pattern: $"{keyPattern}*").Take(1).ToList().Count > 0;
        }

        public bool IsCacheExist(string key)
        {
            return database.KeyExists(key);
        }

        public void Set<T>(string key, T value, TimeSpan? TTL) where T : class
        {
            string serializedObject = GetSerializeObject(value);
            database.StringSet(key, serializedObject, TTL);
        }

        public void Set<T>(string key, IList<T> value, TimeSpan? TTL) where T : class
        {
            string serializedObject = GetSerializeObject(value);
            database.StringSet(key, serializedObject, TTL);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? TTL) where T : class
        {
            await database.StringSetAsync(key, GetSerializeObject(value), TTL);
        }

        public async Task SetAsync<T>(string key, List<T> value, TimeSpan? TTL) where T : class
        {
            await database.StringSetAsync(key, GetSerializeObject(value), TTL);
        }

        public string Get(string key)
        {
            var value = database.StringGet(key);
            
            if (!value.HasValue)
            {
                return default!;
            }

            return value.ToString();
        }

        public Task<string> GetAsync(string key)
        {
            var value = database.StringGetAsync(key);

            if (!value.Result.HasValue)
            {
                return default!;
            }

            return Task.FromResult(value.Result.ToString());
        }

        public bool Remove(string key)
        {
            return database.KeyDelete(key);
        }

        public async Task RemoveAsync(string key)
        {
            await database.KeyDeleteAsync(key);
        }

        private string GetSerializeObject<T>(T value)
        {
            string result = JsonSerializer.Serialize(value, typeof(T));
            return result;
        }
    }
}
