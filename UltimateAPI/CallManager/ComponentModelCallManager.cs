using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class ComponentModelCallManager
    {
        public UltimateResult<List<ComponentModel>> GetComponentModels()
        {
            return ComponentModelManager.Instance.GetComponentModels();
        }

        public UltimateResult<List<ComponentModel>> GetComponentModelByCompanyRefId(ReferansParameter parameter)
        {
            return ComponentModelManager.Instance.GetComponentModelByCompanyRefId(parameter);
        }

        public UltimateResult<List<ComponentModel>> DeleteComponentModel(ComponentModel parameter)
        {
            return ComponentModelManager.Instance.DeleteComponentModel(parameter);
        }

        public UltimateResult<List<ComponentModel>> AddComponentModel(ComponentModel parameter)
        {
            return ComponentModelManager.Instance.AddComponentModel(parameter);
        }

        public UltimateResult<List<ComponentModel>> UpdateComponenModel(ComponentModel parameter)
        {
            return ComponentModelManager.Instance.UpdateComponenModel(parameter);
        }
    }
}
