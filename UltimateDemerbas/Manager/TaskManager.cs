using System.Net.Http;
using System.Threading.Tasks;
using UltimateAPI.Entities;

namespace UltimateDemerbas.Manager
{
    public class TaskManager : BaseManager
    {
        public TaskManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public Task<string> GetTask(Tasks parameter)
        {
            return GetApiParameter<Tasks>("Task/GetTask", parameter);
        }

        public Task<string> GetTasks(Tasks parameter)
        {
            return GetApiParameter<Tasks>("Task/GetTasks", parameter);
        }

        public Task<string> DeleteTask(Tasks parameter)
        {
            return GetApiParameter<Tasks>("Task/DeleteTask", parameter);
        }

        public Task<string> UpdateTask(Tasks parameter)
        {
            return GetApiParameter<Tasks>("Task/UpdateTask", parameter);
        }

        public Task<string> AddTask(Tasks parameter)
        {
            return GetApiParameter<Tasks>("Task/AddTask", parameter);
        }
    }
}
