using System;

namespace iTechArt.Internship.Swagger.API.Tests.Modules
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SourceSystemId { get; set; }
        public Guid TargetSystemId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastExecutionDate { get; set; }
    }
}