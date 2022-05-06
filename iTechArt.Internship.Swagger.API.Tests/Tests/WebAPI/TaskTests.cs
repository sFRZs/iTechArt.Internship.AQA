using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit;

namespace iTechArt.Internship.Swagger.API.Tests.Tests.WebAPI
{
    public class TaskTests
    {
        private readonly WebApiTaskService _webApiTaskService;
        private readonly WebApiSystemService _webApiSystemService;

        public TaskTests()
        {
            _webApiTaskService = new WebApiTaskService
            {
                AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Server),
            };

            _webApiSystemService = new WebApiSystemService
            {
                AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Server),
            };
        }

        [Fact]
        public async Task StatusCode_Of_PostTask_Is_200_And_Task_Add_To_Server()
        {
            // arrange
            var systemModel = RequestModelCreator.CreateSystemModel();
            var system = await _webApiSystemService.PostSystem<SystemVM>(systemModel);
            var taskModel = RequestModelCreator.CreateWebApiTaskModel(system.Data);

            // act
            var response = await _webApiTaskService.PostTask<TaskVM>(taskModel);

            var isValidSchema = JsonValidator.IsValid(response.Content, "TaskSchema.json", out var errors);
            var allTasks = (await _webApiTaskService.GetAllTasksForSystem<IList<TaskVM>>($"{system.Data.Id}")).Data;

            // assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
                allTasks.Should().Contain(t => t.Name == taskModel.Name && t.SourceSystemId == taskModel.SourceSystemId);
            }
        }
    }
}