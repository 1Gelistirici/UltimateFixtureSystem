using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;

namespace UltimateDemerbas.Manager
{
    public class ReportManager : BaseManager
    {
        public ReportManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetReports()
        {
            return GetApi("Report/GetReports");
        }

        public Task<string> GetReportedAssetsByCompany(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Report/GetReportedAssetsByCompany", parameter);
        }

        public Task<string> GetReportsByStatu(ReportStatu reportStatu)
        {
            return GetApiParameter<ReportStatu>("Report/GetReportsByStatu", reportStatu);
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
