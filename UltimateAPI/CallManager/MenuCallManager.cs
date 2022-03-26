using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class MenuCallManager
    {
        private static readonly object Lock = new object();
        private static volatile MenuCallManager _instance;
        public static MenuCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MenuCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

   
    }
}
