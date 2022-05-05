using System;

namespace iTechArt.Internship.Swagger.API.Tests.Models.ViewModels.WebAPI
{
    public class SystemVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ConnectorId { get; set; }
    }
}