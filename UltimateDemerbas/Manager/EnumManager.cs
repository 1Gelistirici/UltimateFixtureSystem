using System.Net.Http;
using System.Threading.Tasks;

namespace UltimateDemerbas.Manager
{
    public class EnumManager : BaseManager
    {
        public EnumManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetIsActiveTypes()
        {
            return GetApi("Enum/GetIsActiveTypes");
        }

        public Task<string> GetItemStatuTypes()
        {
            return GetApi("Enum/GetItemStatuTypes");
        }

        public Task<string> GetItemTypeTypes()
        {
            return GetApi("Enum/GetItemTypeTypes");
        }

        public Task<string> GetReportStatus()
        {
            return GetApi("Enum/GetReportStatus");
        }

        public Task<string> GetProductTypes()
        {
            return GetApi("Enum/GetProductTypes");
        }

        public Task<string> GetDepartments()
        {
            return GetApi("Enum/GetDepartments");
        }

        public Task<string> GetGenders()
        {
            return GetApi("Enum/GetGenders");
        }

        public Task<string> GetImportanceLevels()
        {
            return GetApi("Enum/GetImportanceLevels");
        }

        public Task<string> GetTaskActiveStatus()
        {
            return GetApi("Enum/GetTaskActiveStatus");
        }

        public Task<string> GetLogTypes()
        {
            return GetApi("Enum/GetLogTypes");
        }
    }
}
