using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes;
using Xunit;

namespace iTechArt.Internship.Swagger.API.Tests.Tests
{
    public class NegativeTests
    {
        private readonly TasksService _tasksService;

        public NegativeTests()
        {
            _tasksService = new TasksService();
        }

        [Fact]
        public async Task NotAuthorizeTest()
        {
            
            _tasksService.AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Null);

            var response = await _tasksService.GetAllActiveIndividual();

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Request_with_uncorrected_taskId_fail_with_error_404_notFound()
        {
            _tasksService.AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.ConfigurationFile);
            var response = await _tasksService.GetTaskById<TaskVM>($"{Guid.Empty}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}