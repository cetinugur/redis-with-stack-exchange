using Cache.Core.Enums;
using Cache.Core.Extensions;

namespace Cache.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CacheAttribute : Attribute
    {
        public CachePreferences CachePreferences { get; private set; }

        public CacheAttribute(TimeSpan TTL, string? cacheKeyPrefix = null)
        {
            CachePreferences = new()
            {
                CacheKeyPrefix = cacheKeyPrefix,
                DurationInTimespan = TTL,
                SettedInTimespanDirectly = true
            };
        }

        public CacheAttribute(TTLTypes TTLType, double TTL, string? cacheKeyPrefix = null)
        {
            CachePreferences = new()
            {
                CacheKeyPrefix = cacheKeyPrefix,
                TTLType = TTLType,
                Duration = TTL
            };

            switch (TTLType)
            {
                case TTLTypes.InSeconds:
                    CachePreferences.DurationInTimespan = TTL.ToExpirationFromSeconds();
                    break;
                case TTLTypes.InMinutes:
                    CachePreferences.DurationInTimespan = TTL.ToExpirationFromMinutes();
                    break;
                case TTLTypes.InHours:
                    CachePreferences.DurationInTimespan = TTL.ToExpirationFromHours();
                    break;
                case TTLTypes.InDays:
                    CachePreferences.DurationInTimespan = TTL.ToExpirationFromDays();
                    break;
                default:
                    throw new NotImplementedException(TTLType.ToString());
            }
        }

        /// <summary>
        /// No expire
        /// </summary>
        /// <param name="cacheKeyPrefix"></param>
        public CacheAttribute(string? cacheKeyPrefix = null)
        {
            CachePreferences = new()
            {
                CacheKeyPrefix = cacheKeyPrefix,
                DurationInTimespan = null,
                Duration = null
            };
        }
    }

    public class CachePreferences
    {
        public string? CacheKeyPrefix { get; set; }
        public TTLTypes? TTLType { get; set; }
        public double? Duration { get; set; }
        public TimeSpan? DurationInTimespan { get; set; }
        public bool SettedInTimespanDirectly { get; set; } = false;
        public bool IsNeverExpires => !Duration.HasValue;
    }
}
