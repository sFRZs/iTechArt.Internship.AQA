using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace iTechArt.Internship.Swagger.API.Tests.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _configuration;
        public static IConfiguration Configuration => _configuration.Value;

        public static string BaseUrl => Configuration[nameof(BaseUrl)];
        public static string Token => Configuration[nameof(Token)];

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