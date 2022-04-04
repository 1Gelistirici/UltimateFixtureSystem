using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class CodeManager : BaseManager
    {
        public CodeManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetCode(Code parameter)
        {
            return GetApiParameter<Code>("Code/GetCode", parameter);
        }
    
        public Task<string> AddCode(Code parameter)
        {
            return GetApiParameter<Code>("Code/AddCode", parameter);
        }
    }
}
