using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class LogManager : BaseManager
    {
        public LogManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetLogs(Log parameter)
        {
            return GetApiParameter<Log>("Log/GetLogs", parameter);
        }

        public Task<string> DeleteLog(Log parameter)
        {
            return GetApiParameter<Log>("Log/DeleteLog", parameter);
        }

        public Task<string> GetLogByCompanyRefId(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Log/GetLogByCompanyRefId", parameter);
        }

        public Task<string> AddLog(Log parameter)
        {
            return GetApiParameter<Log>("Log/AddLog", parameter);
        }

    }
}
