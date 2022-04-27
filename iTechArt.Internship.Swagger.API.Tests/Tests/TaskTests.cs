using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Tests
{
    public class TaskTests
    {
        private readonly TasksService _tasksService;
        private readonly LogHelper<TaskTests> _logHelper;

        public TaskTests(ITestOutputHelper testOutputHelper)
        {
            _tasksService = new TasksService
            {
                AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.ConfigurationFile),
                TestOutputHelper = testOutputHelper
            };
            _logHelper = new LogHelper<TaskTests>(testOutputHelper);
        }

        [Fact]
        public async Task StatusCode_Of_GetAllActiveTasks_Is_200()
        {
            // act
            var response = await _tasksService.GetAllActiveTasks<IList<ActiveTaskVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListActiveTasksSchema.json", out var errors);
            _logHelper.TraceResponse(response);
            
            // assert
            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task StatusCode_Of_GetAllActiveTasksGroup_Is_200()
        {
            // act
            var response = await _tasksService.GetAllActiveTasksGroup<IList<ActiveTasksGroupVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListActiveTasksGroupSchema.json", out var errors);
            _logHelper.TraceResponse(response);

            // assert
            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task StatusCode_Of_GetAllActiveIndividual_Is_200()
        {
            // act
            var response = await _tasksService.GetAllActiveIndividual<IList<ActiveIndividualVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListActiveIndividualSchema.json", out var errors);
            _logHelper.TraceResponse(response);

            // assert
            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}