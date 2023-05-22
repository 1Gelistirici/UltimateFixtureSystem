using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class UsedTonerCallManager
    {
        private static readonly object Lock = new object();
        private static volatile UsedTonerCallManager _instance;
        public static UsedTonerCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UsedTonerCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<UsedToner>> GetUsedToners()
        {
            return UsedTonerManager.Instance.GetUsedToners();
        }
        public UltimateResult<List<UsedToner>> GetUsedToner(UsedToner parameter)
        {
            return UsedTonerManager.Instance.GetUsedToner(parameter);
        }
        public UltimateResult<List<UsedToner>> AddUsedToner(UsedToner parameter)
        {
            return UsedTonerManager.Instance.AddUsedToner(parameter);
        }
        public UltimateResult<List<UsedToner>> DeleteUsedToner(UsedToner parameter)
        {
            return UsedTonerManager.Instance.DeleteUsedToner(parameter);
        }
        public UltimateResult<List<UsedToner>> UpdateUsedToner(UsedToner parameter)
        {
            return UsedTonerManager.Instance.UpdateUsedToner(parameter);
        }
        public UltimateResult<List<UsedToner>> GetUsedTonerByCompanyRefId(ReferansParameter parameter)
        {
            return UsedTonerManager.Instance.GetUsedTonerByCompanyRefId(parameter);
        }

    }
}
