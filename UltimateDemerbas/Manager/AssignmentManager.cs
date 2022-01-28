using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class AssignmentManager : BaseManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AssignmentManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> GetAssignments(Assignment parameter)
        {
            return GetApiParameter<Assignment>("Assignment/GetAssignments", parameter);
        }

        public Task<string> DeleteAssignment(Assignment parameter)
        {
            return GetApiParameter<Assignment>("Assignment/DeleteAssignment", parameter);
        }

        public Task<string> UpdateAssignment(Assignment parameter)
        {
            return GetApiParameter<Assignment>("Assignment/UpdateAssignment", parameter);
        }

        public Task<string> AddAssignment(Assignment parameter)
        {
            return GetApiParameter<Assignment>("Assignment/AddAssignment", parameter);
        }

        public Task<string> GetAssignmentUser(Assignment parameter)
        {
            return GetApiParameter<Assignment>("Assignment/GetAssignmentUser", parameter);
        }

    }
}
