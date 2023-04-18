
using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum TaskCount
    {
        [Description("Low")]
        Low = 0,

        [Description("Standard")]
        Standard = 1,

        [Description("High")]
        High = 2,

        [Description("Very High")]
        VeryHigh = 3,
    }
}
