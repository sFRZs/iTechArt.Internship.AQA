using NLog;
using NLog.Targets;
using Xunit.Abstractions;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities.Logger
{
    public class XunitLoggerTarget : TargetWithLayoutHeaderAndFooter
    {
        private readonly ITestOutputHelper _helper;

        public XunitLoggerTarget(ITestOutputHelper helper)
        {
            _helper = helper;
        }

        protected override void Write(LogEventInfo logEvent)
        {
            var logMessage = Layout.Render(logEvent);
            _helper.WriteLine(logMessage);
        }
    }
}