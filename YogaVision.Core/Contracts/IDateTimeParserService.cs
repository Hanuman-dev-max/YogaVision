

namespace YogaVision.Core.Contracts
{
    using System;
   
    /// <summary>
    /// Intereface Service for parsing string to data
    /// </summary>
    public interface IDateTimeParserService
    {
        /// <summary>
        /// Converts the strings to data
        /// </summary>
        /// <param name="date">The string representing the date</param>
        /// <param name="time">The string representing the time</param>
        /// <returns></returns>
        DateTime ConvertStrings(string date, string time);

        string ConvertToString(int hours, int minutes);
    }
}
