using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Services.Classes.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.TaskProcessor;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit;

namespace iTechArt.Internship.Swagger.API.Tests.Tests.TaskProcessor
{
    public class DataTypesTests
    {
        private readonly IDataTypeService _dataTypesService;

        public DataTypesTests()
        {
            _dataTypesService = new DataTypesService
                {AuthToken = AuthTokenFactory.GetToken(AuthTokenPlace.ConfigurationFile)};
        }

        [Fact]
        public async Task StatusCode_Of_GetAllDataTypes_Is_200()
        {
            // act
            var response = await _dataTypesService.GetAllDataTypes<IList<DataTypeVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListDataTypeSchema.json", out var errors);

            // assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
            }
        }

        [Fact]
        public async Task Response_DataTypes_Is_Valid()
        {
            // arrange
            var expected = DataTypeFactory.AllDataTypes();
            var response = await _dataTypesService.GetAllDataTypes<IList<DataTypeVM>>();

            // act
            var actual = response.Data;
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListDataTypeSchema.json", out var errors);

            // assert
            using (new AssertionScope())
            {
                actual.Should().BeEquivalentTo(expected, options => options.Including(x => x.Name));
                isValidSchema.Should().BeTrue($":\n{string.Join(",\n", errors)}\n");
            }
        }
    }
}