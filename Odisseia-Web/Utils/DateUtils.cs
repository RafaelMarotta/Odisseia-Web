using System;

namespace Utils
{
    public static class DateUtils
    {
        public static string FormatTimeSpan(TimeSpan timespan)
        {
            return string.Format("{0}:{1}:{2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
        }

        public static string FormatPercentage(double average)
        {
            return (average * 100).ToString("#.#") + "%";
        }
    }
}
