using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaVision.Common;
using YogaVision.Core.Contracts;

namespace YogaVision.Core.Services.DateTimeParser
{
    public class DateTimeParserService : IDateTimeParserService
    {
        public DateTime ConvertStrings(string date, string time)
        {
            string dateString = date + " " + time;
            string format = GlobalConstants.DateTimeFormats.DateTimeFormat;

            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            return dateTime;
        }
    }
}
