namespace ConfigAgent.API.Behaviours;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = GetStatusCode(exception);

        ContextResponse response = new (exception.Message, exception.GetType().FullName, exception.StackTrace);

        Log.Error(exception, "Exception occured: {Message}", exception.Message);
        
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    
    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            KeyNotFoundException => StatusCodes.Status404NotFound,
            AgentException ex => ex.StatusCode,
            _ => StatusCodes.Status500InternalServerError
        };
}