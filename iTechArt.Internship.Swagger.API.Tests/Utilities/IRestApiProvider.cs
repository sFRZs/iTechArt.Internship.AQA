using iTechArt.Internship.Swagger.API.Tests.Entities.Wrappers;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public interface IRestApiProvider
    {
        public IWrappedRestClient RestClient { get; set; }
        public IRestRequest CreateRequest(string endPoint, string token, Method method = Method.GET,
            object body = null);
    }
}