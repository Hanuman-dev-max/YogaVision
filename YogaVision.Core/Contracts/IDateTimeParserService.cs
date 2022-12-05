

namespace YogaVision.Core.Contracts
{
    using System;
   
    public interface IDateTimeParserService
    {
        DateTime ConvertStrings(string date, string time);

    }
}
