using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class TokenCallManager
    {
        public UltimateResult<List<User>> GenerateToken(User user)
        {
            return TokenManager.Instance.GenerateToken(user);
        }
    }
}
