using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;

namespace HealthCheck
{
    public class CustomHealthCheckOptions : HealthCheckOptions
    {
        public CustomHealthCheckOptions() : base() 
        {
            var jsonSerializerOptions = new JsonSerializerOptions() 
            { 
                WriteIndented = true 
            };

            ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = MediaTypeNames.Application.Json;
                c.Response.StatusCode = StatusCodes.Status200OK;

                var result = JsonSerializer.Serialize(new
                   {
                      checks = r.Entries.Select(e => new
                          {
                              name = e.Key,
                              responseTime = e.Value.Duration.TotalMilliseconds,
                              status = e.Value.Status.ToString(),
                              description = e.Value.Description
                          }),
                      totalStatus = r.Status,
                      totalResponseTime = r.TotalDuration.TotalMilliseconds,
                   }, jsonSerializerOptions);
                await c.Response.WriteAsync(result);
            };
        }
    }
}