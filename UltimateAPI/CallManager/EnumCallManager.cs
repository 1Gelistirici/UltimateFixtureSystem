using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;
using UltimateDemerbas.Models;

namespace UltimateAPI.CallManager
{
    public class EnumCallManager
    {
        private static readonly object Lock = new object();
        private static volatile EnumCallManager _instance;
        public static EnumCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new EnumCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<TextValue>> GetIsActiveTypes()
        {
            return EnumManager.Instance.GetIsActiveTypes();
        }

        public UltimateResult<List<TextValue>> GetItemStatuTypes()
        {
            return EnumManager.Instance.GetItemStatuTypes();
        }

        public UltimateResult<List<TextValue>> GetItemTypeTypes()
        {
            return EnumManager.Instance.GetItemTypeTypes();
        }
    }
}
