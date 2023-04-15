
using System.ComponentModel;

namespace UltimateAPI.Entities.Enums
{
    public enum LogType //Yapılan işlemi belirtir
    {
        [Description("LoginFailed")]
        LoginFailed = 0,

        [Description("LoginSucess")]
        LoginSucess = 1,

        [Description("Add")]
        Add = 2,

        [Description("Delete")]
        Delete = 3,

        [Description("Update")]
        Update = 4,

        [Description("Error")]
        Error = 5
    }
}
