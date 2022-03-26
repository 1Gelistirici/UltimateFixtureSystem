using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UltimateAPI.Entities;

namespace UltimateAPI.Manager
{
    public class MenuManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile MenuManager _instance;
        public static MenuManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MenuManager();
                        }
                    }
                }
                return _instance;
            }

        }


    }
}
