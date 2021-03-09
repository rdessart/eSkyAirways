using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performances.PerformancesData
{
    public class CruiseData
    {
        public Dictionary<string, List<int>> FuelFlow { get; set; }
        public Dictionary<string, List<int>> Tas { get; set; }
        public Dictionary<string, List<int>> OptimumAltitudes { get; set; }
        public Dictionary<string, float> Correction { get; set; }
    }
}
