using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class ItemHistoryCallManager
    {
        public static ItemHistoryManager itemHistory;
        private static readonly object Lock = new object();
        private static volatile ItemHistoryCallManager _instance;
        public static ItemHistoryCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ItemHistoryCallManager();
                            itemHistory = new ItemHistoryManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateResult<List<ItemHistory>> GetItemHistoryByCompany(ReferansParameter parameter)
        {
            return itemHistory.GetItemHistoryByCompany(parameter);
        }

        public UltimateSetResult AddItemHistory(ItemHistory parameter)
        {
            return itemHistory.AddItemHistory(parameter);
        }

    }
}
