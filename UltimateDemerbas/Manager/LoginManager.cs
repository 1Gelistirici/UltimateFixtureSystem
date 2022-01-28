using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class LoginManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> Authenticate(User parameter)
        {
            return GetApiParameter<User>("Login/Authenticate", parameter);
        }

    }
}
