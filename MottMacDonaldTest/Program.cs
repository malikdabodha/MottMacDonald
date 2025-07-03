using Microsoft.AspNetCore.Mvc.ApiExplorer;
using RobotSimulator.Processor.DependencyInjection;
using RobotSimulator.Processor.Utilities.GlobalException;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.

builder.Services.AddControllers();


// Create custom exception handler 
services.AddExceptionHandler<GlobalExceptionMiddleware>();
services.AddProblemDetails();


// Configuring Swagger
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Register Services & add middelware
services.RegisterSetting(builder.Configuration);
services.AddSingletonService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    //app.UseSwagger();
    //app.UseSwaggerUI();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToString());
        }
    });
}

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
