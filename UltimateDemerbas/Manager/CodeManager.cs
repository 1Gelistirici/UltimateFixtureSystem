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

        public Task<string> GetCodeV1(Code parameter)
        {
            return GetApiParameter<Code>("Code/GetCodeV1", parameter);
        }

        public Task<string> IsValidateCode(Code parameter)
        {
            return GetApiParameter<Code>("Code/IsValidateCode", parameter);
        }
    
        public Task<string> AddCode(Code parameter)
        {
            return GetApiParameter<Code>("Code/AddCode", parameter);
        }

    }
}
