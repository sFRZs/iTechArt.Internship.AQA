using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _configuration;
        private static IConfiguration Configuration => _configuration.Value;
        private static IConfigurationSection TaskProcessor => Configuration.GetSection(nameof(TaskProcessor));
        private static IConfigurationSection WebApi => Configuration.GetSection(nameof(WebApi));
        private static IConfigurationSection WebAuth => Configuration.GetSection(nameof(WebAuth));

        public static string BaseUrl => Configuration[nameof(BaseUrl)];
        public static string Token => Configuration[nameof(Token)];

        public static string DataTypesEndpoint => TaskProcessor.GetValue<string>("DataTypesEndpoint");
        public static string AllActiveTasksEndpoint => TaskProcessor.GetValue<string>("AllActiveTasksEndpoint");
        public static string AllActiveTasksGroupEndpoint => TaskProcessor.GetValue<string>("AllActiveTasksGroupEndpoint");
        public static string AllActiveIndividualEndpoint => TaskProcessor.GetValue<string>("AllActiveIndividualEndpoint");
        public static string TaskByIdEndpoint => TaskProcessor.GetValue<string>("TaskByIdEndpoint");

        public static string AllSystemsEndpoint => WebApi.GetValue<string>("AllSystemsEndpoint");
        public static string PostSystemEndpoint => WebApi.GetValue<string>("PostSystemEndpoint");
        public static string AllTasksForSystemEndpoint => WebApi.GetValue<string>("AllTasksForSystemEndpoint");
        public static string PostTaskEndpoint => WebApi.GetValue<string>("PostTaskEndpoint");
        
        public static string BrowserType => WebAuth.GetValue<string>("BrowserType");
        public static string LoginUrl => WebAuth.GetValue<string>("LoginUrl");
        public static string Login => WebAuth.GetValue<string>("Login");
        public static string Password => WebAuth.GetValue<string>("Password");


        static Configurator()
        {
            _configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}