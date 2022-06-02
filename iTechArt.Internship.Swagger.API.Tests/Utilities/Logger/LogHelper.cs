using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using RestSharp;
using Xunit.Abstractions;
using LogFactory = iTechArt.Internship.Swagger.API.Tests.Entities.Factories.LogFactory;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities.Logger
{
    public class LogHelper
    {
      //  private readonly NLog.Logger _log;
        private readonly ILogger _log;
        private readonly ITestOutputHelperAccessor _testOutputHelperAccessor;
        public ITestOutputHelper TestOutputHelper => _testOutputHelperAccessor.Output;

        // public LogHelper(ITestOutputHelper testOutputHelper)
        // {
        //     _log = LogFactory.CreateLogger(testOutputHelper);
        // }
        public LogHelper(IXunitLogger xunitLogger)
        {
           _log = xunitLogger.TestOutputHelper.ToLogger<LogHelper>();
        }
        
        
        
         public void TraceRequest(IRestRequest request)
         {
             _log.LogInformation($"URL         : {request.Resource}");
             _log.LogInformation($"Method      : {request.Method}");
             _log.LogInformation($"Headers     : {request.Parameters}");
             _log.LogInformation($"Request body: {request.Body}");
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