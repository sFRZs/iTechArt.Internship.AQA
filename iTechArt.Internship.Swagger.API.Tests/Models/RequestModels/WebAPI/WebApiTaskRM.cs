using System;

namespace iTechArt.Internship.Swagger.API.Tests.Models.RequestModels.WebAPI
{
    public class WebApiTaskRM
    {
        public string Name { get; set; }
        public Guid SourceSystemId { get; set; }
        public Guid TargetSystemId { get; set; }
        public bool IsActive { get; set; }
    }
}