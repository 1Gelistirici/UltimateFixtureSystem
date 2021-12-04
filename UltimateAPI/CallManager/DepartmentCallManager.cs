using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class DepartmentCallManager
    {
        private static readonly object Lock = new object();
        private static volatile DepartmentCallManager _instance;
        public static DepartmentCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DepartmentCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<Department>> GetDepartments(Department parameter)
        {
            return DepartmentManager.Instance.GetDepartments(parameter);
        }
        public UltimateResult<List<Department>> AddDepartment(Department parameter)
        {
            return DepartmentManager.Instance.AddDepartment(parameter);
        }
        public UltimateResult<List<Department>> DeleteDepartment(Department parameter)
        {
            return DepartmentManager.Instance.DeleteDepartment(parameter);
        }
        public UltimateResult<List<Department>> UpdateDepartment(Department parameter)
        {
            return DepartmentManager.Instance.UpdateDepartment(parameter);
        }
    }
}
