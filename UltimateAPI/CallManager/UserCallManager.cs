using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class UserCallManager
    {
        private static readonly object Lock = new object();
        private static volatile UserCallManager _instance;
        public static UserCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserCallManager();
                        }
                    }
                }
                return _instance;
            }

        }

        public UltimateResult<User> CheckUser(User parameter)
        {
            return UserManager.Instance.CheckUser(parameter);
        }
        public UltimateResult<User> GetUser(User parameter)
        {
            return UserManager.Instance.GetUser(parameter);
        }
        public UltimateResult<List<User>> GetUserCompany(User parameter)
        {
            return UserManager.Instance.GetUserCompany(parameter);
        }
        public UltimateResult<List<User>> GetUsers(User parameter)
        {
            return UserManager.Instance.GetUsers(parameter);
        }
        public UltimateResult<List<User>> ChangePassword(User parameter)
        {
            return UserManager.Instance.ChangePassword(parameter);
        }
        public UltimateResult<User> UpdateProfile(User parameter)
        {
            return UserManager.Instance.UpdateProfile(parameter);
        }
        public UltimateResult<User> AddUser(User parameter)
        {
            return UserManager.Instance.AddUser(parameter);
        }
        public bool DeleteUser(User parameter)
        {
            return UserManager.Instance.DeleteUser(parameter);
        }
        public bool UpdateUser(User parameter)
        {
            return UserManager.Instance.UpdateUser(parameter);
        }
    }
}
