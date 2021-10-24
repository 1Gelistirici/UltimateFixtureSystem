using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class AssignmentCallManager
    {
        private static readonly object Lock = new object();
        private static volatile AssignmentCallManager _instance;
        public static AssignmentCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AssignmentCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Assignment>> GetAssignments(Assignment parameter)
        {
            return AssignmentManager.Instance.GetAssignments(parameter);
        }

        public UltimateResult<List<Assignment>> DeleteAssignment(Assignment parameter)
        {
            return AssignmentManager.Instance.DeleteAssignment(parameter);
        }

        public UltimateResult<List<Assignment>> AddAssignment(Assignment parameter)
        {
            return AssignmentManager.Instance.AddAssignment(parameter);
        }

        public UltimateResult<List<Assignment>> UpdateAssignment(Assignment parameter)
        {
            return AssignmentManager.Instance.UpdateAssignment(parameter);
        }
    }
}
