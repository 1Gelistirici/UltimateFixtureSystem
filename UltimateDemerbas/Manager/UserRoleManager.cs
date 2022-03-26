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

        public Task<string> GetRole(UserRole parameter)
        {
            return GetApiParameter<UserRole>("UserRole/GetRole", parameter);
        }

        public Task<string> AddRole(UserRole parameter)
        {
            return GetApiParameter<UserRole>("UserRole/AddRole", parameter);
        }

        public Task<string> DeleteRole(UserRole parameter)
        {
            return GetApiParameter<UserRole>("UserRole/DeleteRole", parameter);
        }

    }
}
