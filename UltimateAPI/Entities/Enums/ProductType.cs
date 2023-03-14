using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ProductType
    {
        [Description("Fixture")]
        Fixture = 0,
        [Description("Accessory")]
        Accessory = 1,
        [Description("Toner")]
        Toner = 2,
        [Description("Component")]
        Component = 4
    }
}
