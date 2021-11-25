using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class LayoutCallManager
    {
        public UltimateResult<List<Layout>> GetMenus()
        {
            return LayoutManager.Instance.GetMenus();
        }









    }
}
