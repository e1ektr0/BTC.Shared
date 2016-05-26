using System;

namespace BTC.Shared.IoC
{
    public static class SystemDateTimec
    {
        public static Func<DateTime> NowDelegate { get; set; }
        public static Func<DateTime> UtcNowDelegate { get; set; }
        public static DateTime Now => NowDelegate?.Invoke() ?? DateTime.Now;

        public static DateTime UtcNow => UtcNowDelegate?.Invoke() ?? DateTime.UtcNow;

        public static DateTime Today => DateTime.Today;

        public static DateTime GetUserTime(string timeZoneId)
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var time = TimeZoneInfo.ConvertTimeFromUtc(UtcNow, timezone);
            return time;
        }
        public static DateTime GetUserTime(DateTime utc, string timeZoneId)
        {
            var timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var time = TimeZoneInfo.ConvertTimeFromUtc(utc, timezone);
            return time;
        }
    }
}