using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services
{
    public class DataTypesService
    {
        private RestApiProvider _restApiProvider;

        public DataTypesService()
        {
            _restApiProvider = RestApiProvider.GetInstance();
        }
        
        public async Task<IRestResponse> GetAllDataTypes()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.DataTypesEndpoint);
            var response = await _restApiProvider.GetResponse(client, request);

           return response;
        }
        
        public async Task<IRestResponse> GetAllDataTypes<T>()
        {
            var client = _restApiProvider.GetRestClient();
            var request = _restApiProvider.CreateGetRequest(Configurator.DataTypesEndpoint);
            var response = await _restApiProvider.GetResponse<IList<T>>(client, request);

            return response;
        }

        // public async Task<IRestResponse> GetAsync<T>()
        // {
        //     var request = _restApiProvider.CreateGetRequest(Configurator.DataTypesEndpoint);
        //     var response = await _restApiProvider.GetResponse<T>(_restApiProvider.GetRestClient(), request);
        //     return response;
        // }
    }
}