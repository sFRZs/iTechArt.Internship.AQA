using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Classes.WebAPI
{
    public class WebApiTaskService : BaseService, IWebApiTaskService

    {
        public async Task<IRestResponse<T>> GetAllTasksForSystem<T>(string systemId)
        {
            var client = RestApiProvider.GetRestClient();
            var request =
                RestApiProvider.CreateRequest($"{Configurator.AllTasksForSystemEndpoint}{systemId}", AuthToken);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> GetAllTasksForSystem(string systemId)
        {
            var client = RestApiProvider.GetRestClient();
            var request =
                RestApiProvider.CreateRequest($"{Configurator.AllTasksForSystemEndpoint}{systemId}", AuthToken);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> PostTask<T>(object body)
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.PostTaskEndpoint, AuthToken, Method.POST, body);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> PostTask(object body)
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.PostTaskEndpoint, AuthToken, Method.POST, body);

            return await client.ExecuteAsync(request);
        }
    }
}