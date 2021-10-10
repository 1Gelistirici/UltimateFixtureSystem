using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.Token.Helpers
{
    public class AppSettings
    {
        public AppSettings()
        {
            Secret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
        }

        public string Secret { get; set; }
    }
}
