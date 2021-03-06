using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using Microsoft.Extensions.Logging;
using RestSharp;
using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public class LogHelper<T>
    {
        private readonly ILogger<T> _log;

        public LogHelper(ITestOutputHelper testOutputHelper)
        {
            _log = LogFactory.CreateLogger<T>(testOutputHelper);
        }


        public void TraceRequest(IRestRequest request)
        {
            _log.LogDebug($"URL         : {request.Resource}");
            _log.LogDebug($"Method      : {request.Method}");
            _log.LogDebug($"Headers     : {request.Parameters}");
            _log.LogDebug($"Request body: {request.Body}");
        }

        public void TraceResponse(IRestResponse response)
        {
            _log.LogInformation($"Status code  : {response.StatusCode}");
            _log.LogInformation($"Status text  : {response.StatusDescription}");
            _log.LogInformation($"Headers      : {response.Headers}");
            _log.LogInformation($"Response body: {response.Content}");
            
            if (response.ErrorMessage != null)
            {
                _log.LogError($"Errors: {response.ErrorMessage}");
            }
        }
    }
}