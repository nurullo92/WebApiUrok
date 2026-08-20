using AuthentificationPrograms.Logger;

public class LogMiddleware
{
    private readonly RequestDelegate _next;

    public LogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ILoggers logger)
    {
        var clientHttp = context.Connection.RemoteIpAddress?.ToString() ?? "Unkwon";
        logger.EventLog($"Client IP: {clientHttp}");
        await _next(context);

    }
}