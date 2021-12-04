using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class FixLitCallManager
    {
        private static readonly object Lock = new object();
        private static volatile FixLitCallManager _instance;
        public static FixLitCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FixLitCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<FixLic>> AddFixLic(FixLic parameter)
        {
            return FixLicManager.Instance.AddFixLic(parameter);
        }


    }
}
