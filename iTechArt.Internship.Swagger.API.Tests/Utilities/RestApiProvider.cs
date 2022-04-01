using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public class RestApiProvider
    {
        private static RestApiProvider _provider;

        private RestApiProvider()
        {
        }

        public IRestClient GetRestClient()
        {
            return new RestClient(Configurator.BaseUrl);
        }

        public IRestRequest CreateGetRequest(string endPoint)
        {
            var request = new RestRequest(endPoint);
            request.AddHeader("Authorization", Configurator.Token);
            return request;
        }

        public async Task<IRestResponse> GetResponse(IRestClient client, IRestRequest request)
        {
            return await client.ExecuteAsync(request);
        }

        public async Task<IRestResponse<T>> GetResponse(IRestClient client, IRestRequest request)
        {
            return await client.ExecuteAsync<T>(request);
        }

        public IList<T> GetContent<T>(Task<IRestResponse> response)
        {
            var  tmp = JsonSerializer.Deserialize<T>(response.Result.Content);
            
            
            return ;
        }

        public static RestApiProvider GetInstance()
        {
            if (_provider == null)
            {
                _provider = new RestApiProvider();
            }

            return _provider;
        }
    }
}