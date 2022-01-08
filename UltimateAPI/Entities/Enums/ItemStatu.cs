
using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ItemStatu //Demirbaş durumları
    {
        [Description("Stateless")]
        Stateless = 0,

        [Description("Ready")]
        Ready = 1,

        [Description("NotReady")]
        NotReady = 2,

        [Description("Assigned")]
        Assigned = 3
    }
}
