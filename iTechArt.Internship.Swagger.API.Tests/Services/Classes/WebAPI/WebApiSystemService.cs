using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Classes.WebAPI
{
    public class WebApiSystemService : BaseService, IWebApiSystemService
    {
        public async Task<IRestResponse<T>> GetAllSystems<T>()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllSystemsEndpoint, AuthToken);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> GetAllSystems()
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.AllSystemsEndpoint, AuthToken);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> PostSystem<T>(object body)
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.PostSystemEndpoint, AuthToken, Method.POST, body);

            return await client.ExecuteAsync<T>(request);
        }

        public async Task<IRestResponse> PostSystem(object body)
        {
            var client = RestApiProvider.GetRestClient();
            var request = RestApiProvider.CreateRequest(Configurator.PostSystemEndpoint, AuthToken, Method.POST, body);

            return await client.ExecuteAsync(request);
        }
    }
}