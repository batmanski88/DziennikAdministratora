using System;

namespace DziennikAdministratora.Api.Infrastructure.Extensions
{
    public static class DataTimeExtensions
    {
        public static long ToTimeStamp(this DateTime dateTime)
        {
            var epoch = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(epoch.Ticks));
            return time.Ticks / 10000; 
        }
    }
}