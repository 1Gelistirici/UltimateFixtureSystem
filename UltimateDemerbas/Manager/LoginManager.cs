using System.Net.Http;

namespace UltimateDemerbas.Manager
{
    public class LoginManager : BaseManager
    {
        public LoginManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

    }
}
