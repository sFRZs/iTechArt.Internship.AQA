using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Entities;
using iTechArt.Internship.Swagger.API.Tests.Modules;
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
            var expectedDataTypes = DataTypeFactory.AllDataTypes();
            var response = await _dataTypesService.GetAllDataTypes<IList<DataType>>();
            IList<DataType> allDataTypes = response.Data;
            
            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}