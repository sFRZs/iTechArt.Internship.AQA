using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Wrappers
{
    public interface IWrappedRestClient : IRestClient
    {
        public new Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken cancellationToken = default);
        public new  Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken cancellationToken = default);
    }
}