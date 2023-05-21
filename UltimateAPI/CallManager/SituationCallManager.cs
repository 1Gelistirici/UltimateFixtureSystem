using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class SituationCallManager
    {
        public UltimateResult<List<Situation>> GetSituations()
        {
            return SituationManager.Instance.GetSituations();
        }

        public UltimateResult<List<Situation>> GetSituationByCompanyRefId()
        {
            return SituationManager.Instance.GetSituationByCompanyRefId();
        }

        public UltimateResult<List<Situation>> DeleteSituation(Situation parameter)
        {
            return SituationManager.Instance.DeleteSituation(parameter);
        }

        public UltimateResult<List<Situation>> AddSituation(Situation parameter)
        {
            return SituationManager.Instance.AddSituation(parameter);
        }
        
        public UltimateResult<List<Situation>> UpdateSituation(Situation parameter)
        {
            return SituationManager.Instance.UpdateSituation(parameter);
        }
    }
}
