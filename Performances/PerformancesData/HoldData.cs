using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Performances.PerformancesData
{
    public class HoldData
    {
        public Dictionary<string, List<int>> FuelFlow { get; set; }
        public Dictionary<string, float> Correction { get; set; }
    }
}
