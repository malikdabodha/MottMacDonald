using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RobotSimulator.Processor.Interfaces;
using RobotSimulator.Processor.Utilities.Swagger;
using RobotSimulator.Processor.Services;

namespace RobotSimulator.Processor.DependencyInjection;
public static class DependencyInjection
{
    public static void RegisterSetting(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new ApiVersion(11, 12);
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddVersionedApiExplorer(setup => { setup.GroupNameFormat = "'v'VVV"; setup.SubstituteApiVersionInUrl = true; });

        services.ConfigureOptions<SwaggerConfigurationOptions>();
    }

    public static void AddSingletonService(this IServiceCollection services, IConfiguration configuration)
        => services.AddSingleton<IConfiguration>(configuration)
        .AddSingleton<IRobotSimulator, RobotSimulatorServices>();

}