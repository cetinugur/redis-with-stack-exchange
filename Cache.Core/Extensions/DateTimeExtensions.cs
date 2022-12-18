namespace Cache.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static TimeSpan ToExpirationFromSeconds(this double TTL)
        {
            return TimeSpan.FromSeconds(TTL);
        }
        public static TimeSpan ToExpirationFromMinutes(this double TTL)
        {
            return TimeSpan.FromMinutes(TTL);
        }

        public static TimeSpan ToExpirationFromHours(this double TTL)
        {
            return TimeSpan.FromHours(TTL);
        }

        public static TimeSpan ToExpirationFromDays(this double TTL)
        {
            return TimeSpan.FromDays(TTL);
        }
    }
}
