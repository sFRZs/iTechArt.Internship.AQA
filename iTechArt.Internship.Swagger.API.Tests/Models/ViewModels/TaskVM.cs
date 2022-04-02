using System;

namespace iTechArt.Internship.Swagger.API.Tests.Models.ViewModels
{
    public class TaskVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SourceSystemId { get; set; }
        public Guid TargetSystemId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastExecutionDate { get; set; }
    }
}