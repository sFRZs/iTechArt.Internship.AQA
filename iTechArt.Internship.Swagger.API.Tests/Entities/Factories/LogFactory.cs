using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Xunit;
using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Factories
{
    public class LogFactory
    {
        public static ILogger<T> CreateLogger<T>(ITestOutputHelper testOutputHelper)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder
                .AddProvider(new XunitLoggerProvider(testOutputHelper))
            );

            return loggerFactory.CreateLogger<T>();
        }
    }
}