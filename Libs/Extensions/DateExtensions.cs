using System;
using System.Globalization;

namespace champi.Libs.Extensions
{
    public static class DateExtensions
    {
        public static string ConvertToPersianDate(this DateTime value)
        {
            var pc = new PersianCalendar();

            return $"{pc.GetYear(value):D4}/{pc.GetMonth(value):D2}/{pc.GetDayOfMonth(value):D2}";
        }

        public static string ConvertToPersianDate(this DateTime? value)
        {
            if (!value.HasValue) return string.Empty;

            return ConvertToPersianDate(value.Value);
        }
    }
}