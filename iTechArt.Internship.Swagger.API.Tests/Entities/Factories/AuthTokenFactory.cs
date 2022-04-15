using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Utilities;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Factories
{
    public class AuthTokenFactory
    {
        private static string _token = Configurator.Token;

        public static string GetToken(AuthTokenPlace place)
        {
            switch (place)
            {
                case (AuthTokenPlace.ConfigurationFile):
                    _token = Configurator.Token;
                    break;
                case (AuthTokenPlace.Server):
                    _token = null;
                    break;
                case (AuthTokenPlace.Null):
                    _token = null;
                    break;
            }
            // }
            // if (_token == null)
            // {
            //     //some logic
            // }
            //
            // return _token;
            return _token;
        }
    }
}