using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _configuration;
        public static IConfiguration Configuration => _configuration.Value;

        public static string BaseUrl => Configuration[nameof(BaseUrl)];
        public static string Token => Configuration[nameof(Token)];
        public static string DataTypesEndpoint => Configuration[nameof(DataTypesEndpoint)];
        public static string AllActiveTasksEndpoint => Configuration[nameof(AllActiveTasksEndpoint)];
        public static string AllActiveTasksGroupEndpoint => Configuration[nameof(AllActiveTasksGroupEndpoint)];
        public static string AllActiveIndividualEndpoint => Configuration[nameof(AllActiveIndividualEndpoint)];
        public static string TaskByIdEndpoint => Configuration[nameof(TaskByIdEndpoint)];
        

        static  Configurator()
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