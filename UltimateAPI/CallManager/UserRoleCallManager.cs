using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class UserRoleCallManager
    {
        private static readonly object Lock = new object();
        private static volatile UserRoleCallManager _instance;
        public static UserRoleCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserRoleCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<List<UserRole>> GetRole(UserRole parameter)
        {
            return MenuManager.Instance.GetRole(parameter);
        }

        public UltimateResult<List<UserRole>> DeleteRole(UserRole parameter)
        {
            return MenuManager.Instance.DeleteRole(parameter);
        }

        public UltimateResult<List<UserRole>> AddRole(UserRole parameter)
        {
            return MenuManager.Instance.AddRole(parameter);
        }
    }
}