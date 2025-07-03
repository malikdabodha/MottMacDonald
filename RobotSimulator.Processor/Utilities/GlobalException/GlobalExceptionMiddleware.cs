using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace RobotSimulator.Processor.Utilities.GlobalException;
public class GlobalExceptionMiddleware : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception, CancellationToken cancellationToken)
    {
        string message = exception.Message;
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(new { error = exception.Message }, cancellationToken);
        return true;
    }
}