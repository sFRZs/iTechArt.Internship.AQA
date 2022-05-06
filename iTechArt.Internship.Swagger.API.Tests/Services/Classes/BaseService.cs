using iTechArt.Internship.Swagger.API.Tests.Utilities;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Classes
{
    public class BaseService
    {
        protected readonly RestApiProvider RestApiProvider;

        public string AuthToken { get; set; }

        protected BaseService()
        {
            RestApiProvider = RestApiProvider.GetInstance();
        }
    }
}