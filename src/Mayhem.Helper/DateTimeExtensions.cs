using System;

namespace Mayhem.Helper
{
    public static class DateTimeExtensions
    {
        public static DateTime FromUnixTime(this long unixTime)
        {
            DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = epoch.AddSeconds(unixTime);
            return date;
        }

        public static long ToUnixTime(this DateTime date)
        {
            DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }
    }
}
