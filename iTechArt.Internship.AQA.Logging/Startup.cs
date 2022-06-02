using iTechArt.Internship.AQA.Logging.CalculatorFolder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace iTechArt.Internship.AQA.Logging
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient<IXunitLogger, IXunitLogger>();
            service.AddTransient<ICalculator, Calculator>();
        }

        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
        {
            loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor, (s,level) => level >= LogLevel.Debug && level < LogLevel.None));
        }

    }
}