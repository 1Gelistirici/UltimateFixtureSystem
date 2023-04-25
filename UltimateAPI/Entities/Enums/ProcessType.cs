using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ProcessType
    {
        [Description("Ekleme işlemi yapıldı")]
        Insert = 0,

        [Description("Silme işlemi yapıldı")]
        Remove = 1,

        [Description("Güncelleme işlemi yapıldı")]
        Update = 2,

        [Description("Atama işlemi yapıldı")]
        Assignment = 3,

        [Description("Geri alma işlemi yapıldı")]
        Rollback = 4,

    }
}
