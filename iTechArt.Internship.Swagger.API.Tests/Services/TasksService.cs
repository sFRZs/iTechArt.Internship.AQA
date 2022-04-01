using System.Collections.Generic;
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

        // public async Task<IRestResponse> GetAllActiveTasks()
        // {
        //     var client = _restApiProvider.GetRestClient();
        //     var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksEndpoint);
        //     var response = await _restApiProvider.GetResponse(client, request);
        //
        //     return response;
        // } 
        //
        public async Task<IRestResponse<T>> GetAllActiveTasks()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksEndpoint);
            var response = await _restApiProvider.GetResponse<T>(client, request);

            return response;
        }

        public async Task<IRestResponse> GetAllActiveTasksGroup()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksGroupEndpoint);
            var response = await _restApiProvider.GetResponse(client, request);

            return response;
        }
        
        public async Task<IRestResponse> GetAllActiveTasksGroup<T>()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveTasksGroupEndpoint);
            var response = await _restApiProvider.GetResponse<IList<T>>(client, request);

            return response;
        }
        
        public async Task<IRestResponse> GetAllActiveIndividual()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveIndividualEndpoint);
            var response = await _restApiProvider.GetResponse(client, request);

            return response;
        }

        public async Task<IRestResponse> GetAllActiveIndividual<T>()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.AllActiveIndividualEndpoint);
            var response = await _restApiProvider.GetResponse<IList<T>>(client, request);

            return response;
        }
        
        // public async Task<IRestResponse> GetAsync<T>(IRestRequest request)
        // {
        //     var client = _restApiProvider.GetRestClient();
        //     return await _restApiProvider.GetResponse<T>(client, request);
        // }
    }
}