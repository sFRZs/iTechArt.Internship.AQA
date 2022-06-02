using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities.Logger
{
    public class XunitLogger : IXunitLogger
    {
        private readonly ITestOutputHelperAccessor _testOutputHelperAccessor;

        public XunitLogger(ITestOutputHelperAccessor testOutputHelperAccessor)
        {
            _testOutputHelperAccessor = testOutputHelperAccessor;
        }

        public ITestOutputHelper TestOutputHelper => _testOutputHelperAccessor.Output;
    }
}