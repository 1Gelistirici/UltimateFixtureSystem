using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum CodeType
    {
        [Description("None")]
        None = 0,

        [Description("ForgetPassword")]
        ForgetPassword = 1,

        [Description("ValidateEmail")]
        ValidateEmail = 2,

    }
}

