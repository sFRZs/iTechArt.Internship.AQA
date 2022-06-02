using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Classes.TaskProcessor
{
    public class DataTypesService : BaseService, IDataTypesService
    {
        public DataTypesService(IRestApiProvider restApiProvider) : base(restApiProvider)
        {
        }

        public async Task<IRestResponse> GetAllDataTypes()
        {
            var client = RestApiProvider.RestClient;
            var request = RestApiProvider.CreateRequest(Configurator.DataTypesEndpoint, AuthToken);

            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetAllDataTypes<T>()
        {
            var client = RestApiProvider.RestClient;
            var request = RestApiProvider.CreateRequest(Configurator.DataTypesEndpoint, AuthToken);

            return await client.ExecuteAsync<T>(request);
        }
    }
}