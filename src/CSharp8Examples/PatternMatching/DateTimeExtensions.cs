using System;

namespace PatternMatching
{
    static class DateTimeExtensions
    {
        public static void Deconstruct(this DateTime dt, out int day, out int month, out int year) =>
            (day, month, year) = (dt.Day, dt.Month, dt.Year);
    }
}
