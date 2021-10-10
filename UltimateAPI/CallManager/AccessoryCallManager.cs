using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class AccessoryCallManager
    {
        public UltimateResult<List<Accessory>> GetAccessories()
        {
            return AccessoryManager.Instance.GetAccessories();
        }
        
        public UltimateResult<List<Accessory>> GetAccessory(Accessory parameter)
        {
            return AccessoryManager.Instance.GetAccessory(parameter);
        }

        public UltimateResult<List<Accessory>> DeleteAccessory(Accessory parameter)
        {
            return AccessoryManager.Instance.DeleteAccessory(parameter);
        }

        public UltimateResult<List<Accessory>> AddAccessory(Accessory parameter)
        {
            return AccessoryManager.Instance.AddAccessory(parameter);
        }

        public UltimateResult<List<Accessory>> UpdateAccessory(Accessory parameter)
        {
            return AccessoryManager.Instance.UpdateAccessory(parameter);
        }
    }
}
