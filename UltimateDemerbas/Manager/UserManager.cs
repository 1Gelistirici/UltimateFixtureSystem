using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class UserManager : BaseManager
    {
        public UserManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> CheckUser(User parameter)
        {
            return GetApiParameter<User>("User/CheckUser", parameter);
        }

        public Task<string> GetUser(User parameter)
        {
            return GetApiParameter<User>("User/GetUser", parameter);
        }

        public Task<string> GetUserCompany(User parameter)
        {
            return GetApiParameter<User>("User/GetUserCompany", parameter);
        }

        public Task<string> GetUsers(User parameter)
        {
            return GetApiParameter<User>("User/GetUsers", parameter);
        }

        public Task<string> ChangePassword([FromBody] User parameter)
        {
            return GetApiParameter<User>("User/ChangePassword", parameter);
        }

        public Task<string> UpdateProfile(User parameter)
        {
            return GetApiParameter<User>("User/UpdateProfile", parameter);
        }
        
        public Task<string> AddUser(User parameter)
        {
            return GetApiParameter<User>("User/AddUser", parameter);
        }
        
        public Task<string> DeleteUser(User parameter)
        {
            return GetApiParameter<User>("User/DeleteUser", parameter);
        }

    }
}
