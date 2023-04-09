using System.Collections.Generic;
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

        public UltimateResult<Component> GetComponent(ReferansParameter parameter)
        {
            return ComponentManager.Instance.GetComponent(parameter);
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
