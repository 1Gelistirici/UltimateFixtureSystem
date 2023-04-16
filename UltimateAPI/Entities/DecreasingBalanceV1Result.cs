using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.Entities
{
    public class DecreasingBalanceV1Result
    {
        public double DepreciationRate { get; set; }
        public double ApplicableValue { get; set; }
        public double PeriodDepreciation { get; set; }
    }
}
