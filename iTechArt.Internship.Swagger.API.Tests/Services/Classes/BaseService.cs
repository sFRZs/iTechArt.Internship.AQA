using iTechArt.Internship.Swagger.API.Tests.Utilities;
using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Classes
{
    public class BaseService
    {
        protected readonly RestApiProvider RestApiProvider;

        public string AuthToken { get; set; }
        public ITestOutputHelper TestOutputHelper { get; set; }
        protected readonly LogHelper<BaseService> _logHelper;

        protected BaseService()
        {
            RestApiProvider = RestApiProvider.GetInstance();
            _logHelper = new LogHelper<BaseService>(TestOutputHelper);
        }

       
    }
}