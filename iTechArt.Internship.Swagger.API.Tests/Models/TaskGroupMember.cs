﻿using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;

namespace iTechArt.Internship.Swagger.API.Tests.Modules
{
    public class TaskGroupMember
    {
        public int ExecutionOrder { get; set; }
        public TaskVM TaskVm { get; set; }
    }
}