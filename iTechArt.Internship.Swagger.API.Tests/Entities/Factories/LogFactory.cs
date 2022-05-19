using iTechArt.Internship.Swagger.API.Tests.Utilities.Logger;
using NLog;
using NLog.Config;
using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Factories
{
    public class LogFactory
    {
        public static NLog.Logger CreateLogger(ITestOutputHelper testOutputHelper)
        {
            var target = new XunitLoggerTarget(testOutputHelper);
            var config = new LoggingConfiguration();
            config.AddRuleForAllLevels(target);
            
            LogManager.Configuration = config;
            
            return LogManager.GetCurrentClassLogger();
        }
    }
}