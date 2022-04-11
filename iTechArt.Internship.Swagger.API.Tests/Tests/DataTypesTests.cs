using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using iTechArt.Internship.Swagger.API.Tests.Entities;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;
using iTechArt.Internship.Swagger.API.Tests.Services;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit;

namespace iTechArt.Internship.Swagger.API.Tests.Tests
{
    public class DataTypesTests
    {
        private readonly DataTypesService _dataTypesService;


        public DataTypesTests()
        {
            _dataTypesService = new DataTypesService();
        }

        [Fact]
        public async Task StatusCodeOfGetAllDataTypesIs200()
        {
            var response = await _dataTypesService.GetAllDataTypes<IList<DataTypeVM>>();
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListDataTypeSchema.json");

            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task ResponseDataTypesIsValid()
        {
            var expected = DataTypeFactory.AllDataTypes();
            var response = await _dataTypesService.GetAllDataTypes<IList<DataTypeVM>>();
            var actual = response.Data;
            var isValidSchema = JsonValidator.IsValid(response.Content, "IListDataTypeSchema.json");

            using (new AssertionScope())
            {
                isValidSchema.Should().BeTrue();
                actual.Should().BeEquivalentTo(expected, options => options.Including(x => x.Name));
            }
        }
    }
}