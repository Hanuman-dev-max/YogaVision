using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaVision.Infrastructure.Data.Common.Mapping;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Core.Models.Studios
{
    public class StudioSelectListViewModel : IMapFrom<Studio>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
