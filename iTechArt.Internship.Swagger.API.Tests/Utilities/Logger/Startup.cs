using iTechArt.Internship.Swagger.API.Tests.Entities.Wrappers;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.WebAPI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities.Logger
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient(s => new LogHelper(GetRequiredService<XunitLogger>(service)));
            service.AddTransient(s =>
                new WrappedRestClient(Configurator.BaseUrl, GetRequiredService<LogHelper>(service)));
            service.AddTransient(s => new RestApiProvider(GetRequiredService<WrappedRestClient>(service)));
            service.AddTransient(s=>new DataTypesService(GetRequiredService<RestApiProvider>(service)));


            service.AddTransient<IXunitLogger, XunitLogger>();
            service.AddTransient<LogHelper>();
            service.AddTransient<IWrappedRestClient, WrappedRestClient>();
            service.AddTransient<IRestApiProvider, RestApiProvider>();
            service.AddTransient<ITasksService, TasksService>();
            service.AddTransient<IDataTypesService, DataTypesService>();
            service.AddTransient<IWebApiTaskService, WebApiTaskService>();
            service.AddTransient<IWebApiSystemService, WebApiSystemService>();
        }

        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
        {
            loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor,
                (s, level) => level >= LogLevel.Debug && level < LogLevel.None));
        }

        public T GetRequiredService<T>(IServiceCollection service)
        {
            var provider = service.BuildServiceProvider();
            return provider.GetRequiredService<T>();
        }
    }
}