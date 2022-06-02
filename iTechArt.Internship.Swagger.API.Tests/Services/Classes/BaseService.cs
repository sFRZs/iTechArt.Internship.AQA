using iTechArt.Internship.Swagger.API.Tests.Services.Interfaces;
using iTechArt.Internship.Swagger.API.Tests.Utilities;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Classes
{
    public class BaseService : IBaseService
    {
        protected readonly IRestApiProvider RestApiProvider;
        public string AuthToken { get; set; }

        // public BaseService(IXunitLogger xunitLogger)
        // {
        //     RestApiProvider = RestApiProvider.GetInstance();
        //     _xunitLogger = xunitLogger;
        // }  
        public BaseService(IRestApiProvider restApiProvider)
        {
            RestApiProvider = restApiProvider;
        }

        // protected BaseService()
        //  {
        //      RestApiProvider = RestApiProvider.GetInstance();
        //  }
    }
}