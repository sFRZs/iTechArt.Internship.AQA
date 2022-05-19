using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes.WebAPI;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit;

namespace iTechArt.Internship.Swagger.API.Tests.Tests.WebAPI
{
    public class NegativeTests
    {
        private readonly WebApiSystemService _systemService;
        private readonly WebApiTaskService _taskService;

        public NegativeTests()
        {
            _systemService = new WebApiSystemService
            {
                AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Server)
            };
            _taskService = new WebApiTaskService
            {
                AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Server)
            };
        }

        [Fact]
        public async Task Request_Without_Authorize_Fail_With_Error_401_Unauthorized()
        {
            // arrange
            _systemService.AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Null);

            // act
            var response = await _systemService.GetAllSystems();

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Request_PostSystem_With_Incorrect_ConnectorID_Fail_With_Error_400_BadRequest()
        {
            // arrange
            var systemModel = RequestModelCreator.CreateSystemModel();
            systemModel.ConnectorId = "3fa85f64-5717-4562-b3fc-2c963f66afa9";

            // act
            var response = await _systemService.PostSystem(systemModel);
            var isValidSchema = JsonValidator.IsValid(response.Content, "CustomErrorSchema.json", out var errors);

            // assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
            }
        }

        [Fact]
        public async Task Request_GetAllTasksForSystem_With_Uncorrected_SystemId_Fail_With_Error_404_NotFound()
        {
            // act
            var response = await _taskService.GetAllTasksForSystem($"{Guid.Empty}");
            var isValidSchema = JsonValidator.IsValid(response.Content, "CustomErrorSchema.json", out var errors);

            // assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
            }
        }

        [Fact]
        public async Task Request_PostTsk_With_Uncorrected_connectorId_Fail_With_Error_404_NotFound()
        {
            // arrange
            var systemModel = RequestModelCreator.CreateSystemModel();
            var system = await _systemService.PostSystem<SystemVM>(systemModel);
            system.Data.Id = Guid.Empty;

            var taskModel = RequestModelCreator.CreateWebApiTaskModel(system.Data);

            // act
            var response = await _taskService.PostTask(taskModel);
            var isValidSchema = JsonValidator.IsValid(response.Content, "CustomErrorSchema.json", out var errors);

            // assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
            }
        }
    }
}