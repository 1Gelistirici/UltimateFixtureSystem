using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class TonerManager : BaseManager
    {
        public TonerManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetToners()
        {
            return GetApi("Toner/GetToners");
        }

        public Task<string> DeleteToner(Toner parameter)
        {
            return GetApiParameter<Toner>("Toner/DeleteToner", parameter);
        }

        public Task<string> UpdateToner(Toner parameter)
        {
            return GetApiParameter<Toner>("Toner/UpdateToner", parameter);
        }

        public Task<string> AddToner(Toner parameter)
        {
            return GetApiParameter<Toner>("Toner/AddToner", parameter);
        }

        public Task<string> GetTonerByCompanyRefId(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Toner/GetTonerByCompanyRefId", parameter);
        }

    }
}
