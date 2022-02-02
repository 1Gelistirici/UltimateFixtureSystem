using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class ReportManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReportManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetReports()
        {
            return GetApi("Report/GetReports");
        }

        public Task<string> GetPassiveReports()
        {
            return GetApi("Report/GetPassiveReports");
        }

        public Task<string> AddReport(Report parameter)
        {
            return GetApiParameter<Report>("Report/AddReport", parameter);
        }

        public Task<string> UpdateReportStatu(Report parameter)
        {
            return GetApiParameter<Report>("Report/UpdateReportStatu", parameter);
        }
    }
}
