using iTechArt.Internship.Swagger.API.Tests.Entities.Wrappers;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public class RestApiProvider : IRestApiProvider
    {
        private readonly NewtonsoftSerializer _serializer = NewtonsoftSerializer.GetInstance();

        public RestApiProvider(IWrappedRestClient wrappedRestClient)
        {
            RestClient = wrappedRestClient;
        }

        // public IRestClient GetRestClient()
        // {
        //    //return new RestClient(Configurator.BaseUrl);
        //     //return new WrappedRestClient(xunitLogger,Configurator.BaseUrl);
        //     return _restClient;
        // }

        public IWrappedRestClient RestClient { get; set; }

        public IRestRequest CreateRequest(string endPoint, string token, Method method = Method.GET, object body = null)
        {
            var request = new RestRequest(endPoint, method);

            if (token != null)
            {
                request.AddHeader("Authorization", token);
            }

            if (body != null)
            {
                var payload = _serializer.SerializeObject(body);
                request.AddParameter("application/json", payload, ParameterType.RequestBody);
            }

            return request;
        }

        // public static RestApiProvider GetInstance()
        // {
        //     if (_provider == null)
        //     {
        //         _provider = new RestApiProvider();
        //     }
        //
        //     return _provider;
        // }
    }
}