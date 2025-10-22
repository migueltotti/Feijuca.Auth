using Feijuca.Auth.Common.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Feijuca.Auth.Infra.CrossCutting.Extensions
{
    public static class HealthCheckersExtensions
    {
        public static IServiceCollection AddHealthCheckers(this IServiceCollection services, KeycloakSettings keycloakSettings)
        {
            services.AddHealthChecks()
                .AddMongoDb(
                    clientFactory: sp => sp.GetRequiredService<MongoDB.Driver.IMongoClient>(),
                    name: "MongoDB",
                    tags: ["db", "mongo"])
                .AddUrlGroup(
                    new Uri(keycloakSettings.ServerSettings.Url + "/health/ready"),
                    name: "Keycloak-Ready",
                    failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
                    tags: ["keycloak", "auth"]);

            return services;
        }

        public static void UseHealthCheckers(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}