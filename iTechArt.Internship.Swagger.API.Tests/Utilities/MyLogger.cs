using System;
using System.Text;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public class MyLogger<T>
    {
        private ILogger<T> _log;

        public MyLogger()
        {
            _log = CreateLogger<T>();
        }

        private ILogger<T> CreateLogger<T>()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder
                .AddSimpleConsole()
                .AddConsole()
            );

         return loggerFactory.CreateLogger<T>();
        }
        
       

    public void TraceRequest(IRestRequest request) {
    _log.LogInformation("===========================request begin================================================");
    _log.LogDebug($"URI         : {request.Resource}");
    _log.LogDebug($"Method      : {request.Method}");
    _log.LogDebug($"Headers     : {request.Parameters}");
    _log.LogDebug($"Request body: {request.Body}");
    _log.LogInformation("==========================request end================================================");
    }

    public void TraceResponse(IRestResponse response) {
        _log.LogInformation("============================response begin==========================================");
    _log.LogDebug($"Status code  : {response.StatusCode}");
    _log.LogDebug($"Status text  : {response.StatusDescription}");
    _log.LogDebug($"Headers      : {response.Headers}");
    _log.LogDebug($"Response body: {response.Content}");
    _log.LogInformation("=======================response end=================================================");
    }
    }
}