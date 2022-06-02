using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace iTechArt.Internship.AQA.Logging.CalculatorFolder
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