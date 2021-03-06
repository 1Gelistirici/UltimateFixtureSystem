using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class DepartmentManager : BaseManager
    {
        public DepartmentManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public Task<string> GetDepartments(Department parameter)
        {
            return GetApiParameter<Department>("Department/GetDepartments", parameter);
        }

        public Task<string> AddDepartment(Department parameter)
        {
            return GetApiParameter<Department>("Department/AddDepartment", parameter);
        }

        public Task<string> UpdateDepartment(Department parameter)
        {
            return GetApiParameter<Department>("Department/UpdateDepartment", parameter);
        }

        public Task<string> DeleteDepartment(Department parameter)
        {
            return GetApiParameter<Department>("Department/DeleteDepartment", parameter);
        }
    }
}
