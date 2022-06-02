using Xunit.Abstractions;

namespace iTechArt.Internship.AQA.Logging
{
    public interface IXunitLogger
    {
        ITestOutputHelper TestOutputHelper { get; }
    }
}