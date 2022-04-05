using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services
{
    public class DataTypesService
    {
        private readonly RestApiProvider _restApiProvider;

        public DataTypesService()
        {
            _restApiProvider = RestApiProvider.GetInstance();
        }

        public async Task<IRestResponse> GetAllDataTypes()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.DataTypesEndpoint);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetAllDataTypes<T>()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.DataTypesEndpoint);

            return await client.ExecuteAsync<T>(request);
        }
    }
}