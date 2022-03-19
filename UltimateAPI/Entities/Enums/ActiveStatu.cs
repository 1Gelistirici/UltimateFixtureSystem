using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ActiveStatu //Task'ın kapatılma durumunu gösterir
    {
        [Description("Active")]
        Active = 1 << 0,
      
        [Description("Closed")]
        Closed = 1 << 1,
       
        [Description("Solved")]
        Solved = 1 << 2,
       
        [Description("Unsolved")]
        Unsolved = 1 << 3
    }
}
