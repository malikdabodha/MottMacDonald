﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RobotSimulator.Processor.Utilities.Swagger;
internal class SwaggerConfigurationOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    public SwaggerConfigurationOptions(IApiVersionDescriptionProvider provider) => _provider = provider;
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var desc in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(desc.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Mott MacDonald Test",
                Version = desc.ApiVersion.ToString(),
                Description = "Mott MacDonald Test..."
            });
        }
    }
}