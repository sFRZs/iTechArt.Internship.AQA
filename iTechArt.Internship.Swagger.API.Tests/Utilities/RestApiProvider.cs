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

        public IRestRequest CreateGetRequest(string endPoint, object payload = null)
        {
            var request = new RestRequest(endPoint);
            request.AddHeader("Authorization", Configurator.Token);
            if (payload != null )
            {
                request.AddParameter("payload", payload, ParameterType.RequestBody);  
            }
            
            return request;
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