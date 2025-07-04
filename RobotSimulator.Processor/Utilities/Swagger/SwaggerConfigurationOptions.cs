using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

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
                Description = Html()//"Mott MacDonald Test..."
            });
        }
    }

    private string Html()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("<u>");
        stringBuilder.AppendLine("<h1>");
        stringBuilder.AppendLine("The RunCommands method accepts a full list of commands and executes them sequentially.");
        stringBuilder.AppendLine("<br />");
        stringBuilder.AppendLine("Kindly click the link below to download the file that was used for testing the API.");
        stringBuilder.AppendLine("<br />");
        stringBuilder.AppendLine("<b>");
        stringBuilder.AppendLine("<a href='/api/robotsimulator/download-guide' target='_blank'>Download</a>");
        stringBuilder.AppendLine("</b>");
        stringBuilder.AppendLine("</h1>");
        stringBuilder.AppendLine("</u>");
        return stringBuilder.ToString();
    }

}