using System.Collections.Generic;
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
    public class SystemTests
    {
        private readonly WebApiSystemService _webApiSystemService;

        public SystemTests()
        {
            _webApiSystemService = new WebApiSystemService
            {
                AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.Server),
            };
        }

        [Fact]
        public async Task StatusCode_Of_PostSystem_Is_200_And_System_Add_To_Server()
        {
            // arrange
            var systemModel = RequestModelCreator.CreateSystemModel();

            // act
            var response = await _webApiSystemService.PostSystem<SystemVM>(systemModel);

            var isValidSchema = JsonValidator.IsValid(response.Content, "WebApiSystemSchema.json", out var errors);
            var allSystems = (await _webApiSystemService.GetAllSystems<IList<SystemVM>>()).Data;

            // assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
                allSystems.Should().Contain(s => s.Name == systemModel.Name && s.Url == systemModel.Url);
            }
        }
    }
}