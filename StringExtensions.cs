using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVanguard
{
    public static class Extensions
    {
        public static string HandleNull(this string value, string defaultValue = "N/A")
        {
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        public static string HandleNullDate(this DateTime? date, string format = "yyyy-MM-dd", string defaultValue = "N/A")
        {
            return date.HasValue ? date.Value.ToString(format) : defaultValue;
        }
    }
}
