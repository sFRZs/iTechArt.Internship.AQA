using System.Threading;
using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Utilities.Logger;
using RestSharp;
using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Wrappers
{
    public class WrappedRestClient : RestClient, IWrappedRestClient
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly LogHelper _log;

        public WrappedRestClient(string baseUrl, LogHelper logHelper) : base(baseUrl)
        {
            _log = logHelper;
        }

        public new async Task<IRestResponse> ExecuteAsync(IRestRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await base.ExecuteAsync(request, cancellationToken);

            _log.TraceRequest(request);
            _log.TraceResponse(response);

            return response;
        }

        public new async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await base.ExecuteAsync<T>(request, cancellationToken);

            _log.TraceRequest(request);
            _log.TraceResponse(response);

            return response;
        }
    }
}