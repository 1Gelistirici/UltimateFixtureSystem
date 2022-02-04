using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ReportStatu //Itemler için açılan raporların durumları
    {
        [Description("Active")]
        Active = 0,

        [Description("Delete")]
        Delete = 1,
        
        [Description("Closed")]
        Closed = 2,
        
        [Description("Resolved")]
        Resolved = 3
    }
}
