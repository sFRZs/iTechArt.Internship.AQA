
using iTechArt.Internship.Swagger.API.Tests.Modules;
using iTechArt.Internship.Swagger.API.Tests.Services;

using NUnit.Framework;

namespace iTechArt.Internship.Swagger.API.Tests.Tests
{
    public class DataTypesTests
    {
        private DataTypesService _dataTypesService;

        [SetUp]
        public void SetUp()
        {
            _dataTypesService = new DataTypesService();
        }

        [Test]
        public void StatusCodeOfGetAllDataTypesIs200()
        {
            var response = _dataTypesService.GetAllDataTypes<DataType>();
            Assert.AreEqual(200, (int) response.Result.StatusCode);
        }
    }
}