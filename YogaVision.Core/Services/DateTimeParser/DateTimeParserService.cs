

namespace YogaVision.Core.Services.DateTimeParser
{
    using System;
    using System.Globalization;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    /// <summary>
    /// Intereface Service for parsing string to data
    /// </summary>
    public class DateTimeParserService : IDateTimeParserService
    {
        /// <summary>
        /// Converts the strings to data
        /// </summary>
        /// <param name="date">The string representing the date</param>
        /// <param name="time">The string representing the time</param>
        /// <returns></returns>
        public DateTime ConvertStrings(string date, string time)
        {
            string dateString = date + " " + time;
            string format = GlobalConstants.DateTimeFormats.DateTimeFormat;
            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}
