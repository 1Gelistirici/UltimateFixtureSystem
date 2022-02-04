using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ProductType
    {
        [Description("Fixture")]
        Fixture,
        [Description("Accessory")]
        Accessory,
        [Description("Toner")]
        Toner,
        [Description("Component")]
        Component
    }
}
