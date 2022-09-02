using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.Tasks;

namespace Mayhem.HealthCheck
{
    public abstract class HealthControllerBase : Controller
    {
        private readonly HealthCheckService _healthCheckService;

        protected HealthControllerBase(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        protected async Task<ActionResult> CheckHealthAsync(string healthCheckName)
        {
            HealthReport report = await _healthCheckService.CheckHealthAsync(s => s.Name == healthCheckName);

            return report.Entries.Count == 1 ? Ok(report.Status.ToString()) : NotFound();
        }
    }
}
