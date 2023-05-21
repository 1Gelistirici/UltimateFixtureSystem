using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class FixtureModelCallManager
    {
        public UltimateResult<List<FixtureModel>> GetFixtureModels()
        {
            return FixtureModelManager.Instance.GetFixtureModels();
        }

        public UltimateResult<List<FixtureModel>> DeleteFixtureModel(FixtureModel parameter)
        {
            return FixtureModelManager.Instance.DeleteFixtureModel(parameter);
        }

        public UltimateResult<List<FixtureModel>> AddFixtureModel(FixtureModel parameter)
        {
            return FixtureModelManager.Instance.AddFixtureModel(parameter);
        }

        public UltimateResult<List<FixtureModel>> GetFixtureModelByCompanyRefId(ReferansParameter parameter)
        {
            return FixtureModelManager.Instance.GetFixtureModelByCompanyRefId(parameter);
        }

        public UltimateResult<List<FixtureModel>> UpdateFixtureModel(FixtureModel parameter)
        {
            return FixtureModelManager.Instance.UpdateFixtureModel(parameter);
        }
    }
}
