using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class RelevantPersonnelCallManager
    {
        private static readonly object Lock = new object();
        private static volatile RelevantPersonnelCallManager _instance;
        public static RelevantPersonnelCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RelevantPersonnelCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<RelevantPersonnel>> DeleteRelevantPersonnel(ReferansParameter parameter)
        {
            return RelevantPersonnelManager.Instance.DeleteRelevantPersonnel(parameter);
        }

        public UltimateResult<List<RelevantPersonnel>> GetRelevantPersonnels(ReferansParameter parameter)
        {
            return RelevantPersonnelManager.Instance.GetRelevantPersonnels(parameter);
        }

        public UltimateResult<List<RelevantPersonnel>> AddRelevantPersonnel(RelevantPersonnel parameter)
        {
            return RelevantPersonnelManager.Instance.AddRelevantPersonnel(parameter);
        }
    }
}
