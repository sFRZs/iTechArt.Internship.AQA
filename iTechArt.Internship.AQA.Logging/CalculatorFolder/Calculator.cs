using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace iTechArt.Internship.AQA.Logging.CalculatorFolder
{
    public class Calculator :  ICalculator
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly ILogger _logger;

        public Calculator(IXunitLogger xunitLogger)
        {
            _logger = xunitLogger.TestOutputHelper.ToLogger<Calculator>();
        }
        
        public int Sum(int a, int b)
        {
            _logger.LogInformation($"a = {a}, b  = {b}");
            var sum = a + b;
            _logger.LogInformation($"Sum = {sum}");
            return sum;
        }
    }
}