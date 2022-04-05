using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services
{
    public class TasksService
    {
        private RestApiProvider _restApiProvider;

        public TasksService()
        {
            _restApiProvider = RestApiProvider.GetInstance();
        }

        public async Task<IRestResponse> GetAllActiveTasks()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksEndpoint);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetAllActiveTasks<T>()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksEndpoint);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> GetAllActiveTasksGroup()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksGroupEndpoint);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse> GetAllActiveTasksGroup<T>()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksGroupEndpoint);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> GetAllActiveIndividual()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveIndividualEndpoint);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse> GetAllActiveIndividual<T>()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveIndividualEndpoint);

            return await client.ExecuteAsync<T>(request);
        }
    }
}