using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class UserRoleManager : BaseManager
    {
        public UserRoleManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetUserRoleCompany(UserRole parameter)
        {
            return GetApiParameter<UserRole>("UserRole/GetUserRoleCompany", parameter);
        }

    }
}
