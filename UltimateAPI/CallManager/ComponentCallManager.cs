using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class ComponentCallManager
    {
        public UltimateResult<List<Component>> GetComponents()
        {
            return ComponentManager.Instance.GetComponents();
        }

        public UltimateResult<List<Component>> DeleteComponent(Component parameter)
        {
            return ComponentManager.Instance.DeleteComponent(parameter);
        }

        public UltimateResult<List<Component>> AddComponent(Component parameter)
        {
            return ComponentManager.Instance.AddComponent(parameter);
        }

        public UltimateResult<List<Component>> UpdateComponent(Component parameter)
        {
            return ComponentManager.Instance.UpdateComponent(parameter);
        }
    }
}
