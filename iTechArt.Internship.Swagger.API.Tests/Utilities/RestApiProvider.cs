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

        public IRestRequest CreateRequest(string endPoint, string token, Method method = Method.GET)
        {
            var request = new RestRequest(endPoint, method);
            if (token != null)
            {

                request.AddHeader("Authorization", token);
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