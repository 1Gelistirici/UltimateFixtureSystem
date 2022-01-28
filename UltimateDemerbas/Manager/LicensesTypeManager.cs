using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class LicensesTypeManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LicensesTypeManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<string> GetLicensesTypes()
        {
            return GetApi("LicanseType/GetLicensesTypes");
        }

        public Task<string> GetLicensesType(LicensesType parameter)
        {
            return GetApiParameter<LicensesType>("LicanseType/GetLicensesType", parameter);
        }

        public Task<string> DeleteLicensesType(LicensesType parameter)
        {
            return GetApiParameter<LicensesType>("LicanseType/DeleteLicensesType", parameter);
        }

        public Task<string> AddLicenseType(LicensesType parameter)
        {
            return GetApiParameter<LicensesType>("LicanseType/AddLicenseType", parameter);
        }

        public Task<string> UpdateLicenseType(LicensesType parameter)
        {
            return GetApiParameter<LicensesType>("LicanseType/UpdateLicenseType", parameter);
        }

    }
}
