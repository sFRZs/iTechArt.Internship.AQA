using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities.Logger
{
    public interface IXunitLogger
    {
        ITestOutputHelper TestOutputHelper { get; }
    }
}