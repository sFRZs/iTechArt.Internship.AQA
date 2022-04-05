using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using iTechArt.Internship.Swagger.API.Tests.Entities;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;
using iTechArt.Internship.Swagger.API.Tests.Services;
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
            Assert.Equal(200, (int) response.StatusCode);
        }

        [Fact]
        public async Task ResponseDataTypesIsValid()
        {
            var expected = DataTypeFactory.AllDataTypes();
            var response = await _dataTypesService.GetAllDataTypes<IList<DataTypeVM>>();
            var actual = response.Data;
            
            actual.Should().BeEquivalentTo(expected, options=>options.Including(x=>x.Name));
        }
    }
}