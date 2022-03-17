using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum ImportanceLevel//Task önem çeşitleri
    {
        [Description("Not Serious")]
        NotSerious = 1 << 0,

        [Description("Standard")]
        Standard = 1 << 1,

        [Description("important")]
        important = 1 << 2,

        [Description("Very important")]
        VeryImportant = 1 << 3
    }
}
