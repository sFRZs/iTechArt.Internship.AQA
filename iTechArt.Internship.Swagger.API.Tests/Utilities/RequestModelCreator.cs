using System;
using iTechArt.Internship.Swagger.API.Tests.Models.RequestModels.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels.WebAPI;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public class RequestModelCreator
    {
        private static object _systemService;

        public static SystemRM CreateSystemModel()
        {
            var system = new SystemRM
            {
                Name = $"system-{new Random().Next(0, 1000)}",
                Url = "someUrl",
                ConnectorId = "fb6a0b9e-f445-4017-95c6-482b83d056b2"
            };

            return system;
        }

        public static WebApiTaskRM CreateWebApiTaskModel(SystemVM system)
        {
            var task = new WebApiTaskRM
            {
                Name = $"task-{new Random().Next(0, 1000)}",
                SourceSystemId = system.Id,
                TargetSystemId = system.Id,
                IsActive = false
            };

            return task;
        }
    }
}