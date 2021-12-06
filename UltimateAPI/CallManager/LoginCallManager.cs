using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class LoginCallManager
    {
        public UltimateResult<List<User>> Authenticate(User Parameter)
        {
            return LoginManager.Instance.Authenticate(Parameter);
        }
    }
}
