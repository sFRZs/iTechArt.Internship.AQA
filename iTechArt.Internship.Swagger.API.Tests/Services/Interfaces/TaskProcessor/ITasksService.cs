using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.TaskProcessor
{
    public interface ITasksService
    {
        public Task<IRestResponse> GetAllActiveTasks();
        public Task<IRestResponse> GetAllActiveTasksGroup();
        public Task<IRestResponse> GetAllActiveIndividual();
        public Task<IRestResponse<T>> GetAllActiveTasks<T>();
        public Task<IRestResponse<T>> GetAllActiveTasksGroup<T>();
        public Task<IRestResponse<T>> GetAllActiveIndividual<T>();
    }
}