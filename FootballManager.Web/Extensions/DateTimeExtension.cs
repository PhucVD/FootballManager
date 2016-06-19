using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballManager.Web.Extensions
{
    public static class DateTimeExtension
    {
        public static string Format(this DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy");
        }

        public static string Format(this DateTime? dt)
        {
            return dt?.ToString("dd/MM/yyyy");
        }
    }
}