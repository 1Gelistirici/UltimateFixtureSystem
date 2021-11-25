using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class AccessoryModelCallManager
    {
        public UltimateResult<List<AccessoryModel>> GetAccessoryModels()
        {
            return AccessoryModelManager.Instance.GetAccessoryModels();
        }

        public UltimateResult<List<AccessoryModel>> DeleteAccessoryModel(AccessoryModel parameter)
        {
            return AccessoryModelManager.Instance.DeleteAccessoryModel(parameter);
        }

        public UltimateResult<List<AccessoryModel>> AddAccessoryModel(AccessoryModel parameter)
        {
            return AccessoryModelManager.Instance.AddAccessoryModel(parameter);
        }

        public UltimateResult<List<AccessoryModel>> UpdateAccessoryModel(AccessoryModel parameter)
        {
            return AccessoryModelManager.Instance.UpdateAccessoryModel(parameter);
        }
    }
}
