using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services
{
    public class Helper
    {
        public RestClient GetNewRestClient()
        {
            return new RestClient(Configurator.BaseUrl);
        }

        public RestRequest GetNewGetRequest(string endPoint,  Method method = Method.Get)
        {
            var request = new RestRequest(endPoint, method);
            request.AddHeader("Authorization", Configurator.Token);
            return request;
        }

        public async Task<RestResponse> GetResponse(RestClient client, RestRequest request)
        {
            return await client.ExecuteAsync(request);
        }
    }
}