using System.ComponentModel;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Utilities;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Factories
{
    public static class AuthTokenFactory
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
                    _token = new WebAuthenticationService().GetToken();
                    break;
                case (AuthTokenPlace.Null):
                    _token = null;
                    break;
                default:
                    throw new InvalidEnumArgumentException("This option not defined in enum.");
            }

            return _token;
        }
    }
}