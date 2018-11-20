using System;

namespace WorkoutHelper.Extensions
{
    static class DateTimeExtensions
    {
        public static double ToDouble(this DateTime d)
        {
            return d.Ticks / 10000000000.0;
        }
    }
}
