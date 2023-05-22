using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class TonerCallManager
    {
        public UltimateResult<List<Toner>> GetToners()
        {
            return TonerManager.Instance.GetToners();
        }

        public UltimateResult<List<Toner>> DeleteToner(Toner parameter)
        {
            return TonerManager.Instance.DeleteToner(parameter);
        }

        public UltimateResult<List<Toner>> AddToner(Toner parameter)
        {
            return TonerManager.Instance.AddToner(parameter);
        }

        public UltimateResult<List<Toner>> UpdateToner(Toner parameter)
        {
            return TonerManager.Instance.UpdateToner(parameter);
        }

        public UltimateResult<List<Toner>> GetTonerByCompanyRefId(ReferansParameter parameter)
        {
            return TonerManager.Instance.GetTonerByCompanyRefId(parameter);
        }

    }
}
