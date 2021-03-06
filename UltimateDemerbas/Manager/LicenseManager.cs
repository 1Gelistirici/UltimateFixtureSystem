using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class LicenseManager : BaseManager
    {
        public LicenseManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetLicenses()
        {
            return GetApi("License/GetLicenses");
        }

        public Task<string> DeleteLicense(License parameter)
        {
            return GetApiParameter<License>("License/DeleteLicense", parameter);
        }

        public Task<string> UpdateLicense(License parameter)
        {
            return GetApiParameter<License>("License/UpdateLicense", parameter);
        }

        public Task<string> AddLicense(License parameter)
        {
            return GetApiParameter<License>("License/AddLicense", parameter);
        }

    }
}
