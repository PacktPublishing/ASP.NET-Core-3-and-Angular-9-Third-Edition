using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace HealthCheck
{
    public class ICMPHealthCheck : IHealthCheck
    {
        private string Host { get; set; }
        private int Timeout { get; set; }

        public ICMPHealthCheck(string host, int timeout)
        {
            Host = host;
            Timeout = timeout;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(Host);

                    switch (reply.Status)
                    {
                        case IPStatus.Success:
                            var msg = String.Format(
                                "IMCP to {0} took {1} ms.",
                                Host,
                                reply.RoundtripTime);

                            return (reply.RoundtripTime > Timeout)
                                ? HealthCheckResult.Degraded(msg)
                                : HealthCheckResult.Healthy(msg);

                        default:
                            var err = String.Format(
                                "IMCP to {0} failed: {1}",
                                Host,
                                reply.Status);
                            return HealthCheckResult.Unhealthy(err);
                    }
                }
            }
            catch (Exception e)
            {
                var err = String.Format(
                    "IMCP to {0} failed: {1}",
                    Host,
                    e.Message);
                return HealthCheckResult.Unhealthy(err);
            }
        }
    }
}