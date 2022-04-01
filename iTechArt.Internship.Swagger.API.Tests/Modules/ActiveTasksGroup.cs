using System;
using System.Collections.Generic;

namespace iTechArt.Internship.Swagger.API.Tests.Modules
{
    public class ActiveTasksGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastTriggeredTime { get; set; }
        public bool IsActive { get; set; }
        public List<TaskGroupMember> TaskGroupMembers { get; set; }
    }
}