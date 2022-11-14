using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaVision.Core.Contracts
{
    public interface IDateTimeParserService
    {
        DateTime ConvertStrings(string date, string time);

    }
}
