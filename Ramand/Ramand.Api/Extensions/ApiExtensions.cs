using Microsoft.AspNetCore.Mvc;
using Ramand.Infrastructure.Common;

namespace Ramand.Api.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddApiVersioningConfigs(this IServiceCollection serivces)
        {
            serivces.AddApiVersioning(config =>
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
            });

            serivces.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            serivces.ConfigureOptions<ConfigureSwaggerOptions>();

            return serivces;
        }
    }
}
