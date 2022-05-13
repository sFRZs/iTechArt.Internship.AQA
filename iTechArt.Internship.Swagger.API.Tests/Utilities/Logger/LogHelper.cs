using RestSharp;
using Xunit.Abstractions;
using LogFactory = iTechArt.Internship.Swagger.API.Tests.Entities.Factories.LogFactory;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities.Logger
{
    public class LogHelper
    {
        private readonly NLog.Logger _log;

        public LogHelper(ITestOutputHelper testOutputHelper)
        {
            _log = LogFactory.CreateLogger(testOutputHelper);
        }

        public void TraceRequest(IRestRequest request)
        {
            _log.Info($"URL         : {request.Resource}");
            _log.Info($"Method      : {request.Method}");
            _log.Info($"Headers     : {request.Parameters}");
            _log.Info($"Request body: {request.Body}");
        }

        public void TraceResponse(IRestResponse response)
        {
            _log.Info($"Status code  : {response.StatusCode}");
            _log.Info($"Status text  : {response.StatusDescription}");
            _log.Info($"Headers      : {response.Headers}");
            _log.Info($"Response body: {response.Content}");

            if (response.ErrorMessage != null)
            {
                _log.Error($"Errors: {response.ErrorMessage}");
            }
        }
    }
}