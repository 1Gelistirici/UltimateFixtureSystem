using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class CompanyManager : BaseManager
    {
        public CompanyManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetCompanies()
        {
            return GetApi("Company/GetCompanies");
        }

        public Task<string> GetCompanyGroup(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Company/GetCompanyGroup", parameter);
        }

        public Task<string> GetCompany(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Company/GetCompany", parameter);
        }
        public Task<string> DeleteCompany(ReferansParameter parameter)
        {
            return GetApiParameter<ReferansParameter>("Company/DeleteCompany", parameter);
        }

        public Task<string> AddCompany(Company parameter)
        {
            return GetApiParameter<Company>("Company/AddCompany", parameter);
        }

        public Task<string> UpdateCompany(Company parameter)
        {
            return GetApiParameter<Company>("Company/UpdateCompany", parameter);
        }

    }
}
