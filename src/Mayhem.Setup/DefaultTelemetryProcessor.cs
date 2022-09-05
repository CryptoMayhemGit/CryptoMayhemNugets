using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace Mayhem.Setup
{
    public class DefaultTelemetryProcessor : ITelemetryProcessor
    {
        private ITelemetryProcessor Next { get; set; }

        public DefaultTelemetryProcessor(ITelemetryProcessor next)
        {
            Next = next;
        }

        public void Process(ITelemetry item)
        {
            if (item is RequestTelemetry telemetry)
            {
                if (telemetry.Url == null || !telemetry.Url.AbsoluteUri.Contains("api"))
                {
                    return;
                }
            }
            Next.Process(item);
        }
    }
}
