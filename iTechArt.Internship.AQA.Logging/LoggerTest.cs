using iTechArt.Internship.AQA.Logging.CalculatorFolder;
using Xunit;

namespace iTechArt.Internship.AQA.Logging
{
    public class LoggerTest
    {
        private readonly ICalculator _calculator;

        public LoggerTest(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [Fact]
        public void SumTest()
        {
            Assert.Equal(3, _calculator.Sum(1, 2));
        }
    }
}