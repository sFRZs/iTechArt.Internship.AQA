using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit;

namespace iTechArt.Internship.Swagger.API.Tests.Tests.TaskProcessor
{
    public class NegativeTests
    {
        private readonly TasksService _tasksService;

        public NegativeTests()
        {
            _tasksService = new TasksService();
        }

        [Fact]
        public async Task Request_Without_Authorize_Fail_With_Error_401_Unauthorized()
        {
            // arrange
            _tasksService.AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Null);

            // act
            var response = await _tasksService.GetAllActiveIndividual<ErrorModelVM>();
            var errorMessage = response.Data.Errors.AuthorizationHeader[0];

            // assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
                errorMessage.Should().Be("No Authorization data has been provided");
            }
        }

        [Fact]
        public async Task Request_With_Uncorrected_TaskId_Fail_With_Error_404_NotFound()
        {
            // arrange
            _tasksService.AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.ConfigurationFile);

            // act
            var response = await _tasksService.GetTaskById($"{Guid.Empty}");
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