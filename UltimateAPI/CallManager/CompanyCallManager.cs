using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateAPI.CallManager
{
    public class CompanyCallManager
    {
        private static readonly object Lock = new object();
        private static volatile CompanyCallManager _instance;
        public static CompanyCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CompanyCallManager();
                        }
                    }
                }
                return _instance;
            }
        }




    }
}
