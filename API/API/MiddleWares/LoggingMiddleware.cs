namespace API.MiddleWares
{
    public class LoggingMiddleware
    {
        private RequestDelegate next;
        private ILogger<LoggingMiddleware> logger;
        public LoggingMiddleware(RequestDelegate _next, ILogger<LoggingMiddleware> _logger)
        {
            next= _next;
            logger= _logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation($"Request: {context.Request.Method} |{context.Request.Path} at {DateTime.Now} ");
            await next(context);

            logger.LogInformation($"Response: {context.Response.StatusCode} at {DateTime.Now}");

        }
    }
}
