using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performances.PerformancesData
{
    public class ClimbData
    {
        public Dictionary<string, List<int>> Fuel { get; set; }
        public Dictionary<string, List<int>> Distance { get; set; }
        public Dictionary<string, List<int>> Time { get; set; }
        public Dictionary<string, List<int>> Tas { get; set; }
        public Dictionary<string, float> Correction { get; set; }
    }
}
