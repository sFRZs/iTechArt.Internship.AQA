using System;
using System.Collections.Generic;

namespace iTechArt.Internship.Swagger.API.Tests.Models.ViewModels
{
    public class ActiveTasksGroupVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastTriggeredTime { get; set; }
        public bool IsActive { get; set; }
        public List<TaskGroupMemberVM> TaskGroupMembers { get; set; }
    }
}