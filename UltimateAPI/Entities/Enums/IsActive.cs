using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.Entities.Enums
{
    public enum IsActive
    {
        NotSerious = 1 << 0,
        Urgent = 1 << 1,
        Standard = 1 << 2,
        VeryUrgent = 1 << 3
    }
}
