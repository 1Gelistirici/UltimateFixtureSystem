using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ItemType //Assign Tİpi
    {
        [Description("Bill")]
        Bill = 1,

        [Description("Accessory")]
        Accessory = 2,

        [Description("Companent")]
        Companent = 3,

        [Description("Fixture")]
        Fixture = 4,

        [Description("Licence")]
        Licence = 5,

        [Description("Toner")]
        Toner = 6
    }
}
