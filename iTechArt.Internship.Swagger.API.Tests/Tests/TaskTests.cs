using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;
using iTechArt.Internship.Swagger.API.Tests.Services;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit;

namespace iTechArt.Internship.Swagger.API.Tests.Tests
{
    public class TaskTests
    {
        private TasksService _tasksService;

        public TaskTests()
        {
            _tasksService = new TasksService();
        }

        [Fact]
        public async Task StatusCodeOfGetAllActiveTasksIs200()
        {
            var response = await _tasksService.GetAllActiveTasks<IList<ActiveTaskVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListActiveTasksSchema.json");

            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task StatusCodeOfGetAllActiveTasksGroupIs200()
        {
            var response = await _tasksService.GetAllActiveTasksGroup<IList<ActiveTasksGroupVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListActiveTasksGroupSchema.json");

            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task StatusCodeOfGetAllActiveIndividualIs200()
        {
            var response = await _tasksService.GetAllActiveIndividual<IList<ActiveIndividualVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListActiveIndividualSchema.json");

            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}