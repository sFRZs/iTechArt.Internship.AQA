using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Classes
{
    public class TasksService : BaseService, ITasksService
    {
        public async Task<IRestResponse> GetAllActiveTasks()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllActiveTasksEndpoint, AuthToken);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetAllActiveTasks<T>()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllActiveTasksEndpoint, AuthToken);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> GetAllActiveTasksGroup()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllActiveTasksGroupEndpoint, AuthToken);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetAllActiveTasksGroup<T>()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllActiveTasksGroupEndpoint, AuthToken);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> GetAllActiveIndividual()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllActiveIndividualEndpoint, AuthToken);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetAllActiveIndividual<T>()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllActiveIndividualEndpoint, AuthToken);

            return await client.ExecuteAsync<T>(request);
        }
        
        public async Task<IRestResponse> GetTaskById(string taskId)
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest($"{Configurator.TaskByIdEndpoint}{taskId}", AuthToken);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetTaskById<T>(string taskId)
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest($"{Configurator.TaskByIdEndpoint}{taskId}", AuthToken);

            return await client.ExecuteAsync<T>(request);
        }
        
    }
}