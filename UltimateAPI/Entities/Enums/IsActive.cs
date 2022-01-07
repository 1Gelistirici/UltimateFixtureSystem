
using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum IsActive //Task önem çeşitleri
    {
        [Description("NotSerious")]
        NotSerious = 1 << 0,
      
        [Description("Urgent")]
        Urgent = 1 << 1,
       
        [Description("Standard")]
        Standard = 1 << 2,
       
        [Description("VeryUrgent")]
        VeryUrgent = 1 << 3
    }
}
