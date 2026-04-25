namespace API.MiddleWares
{
    public class ExceptionMiddleware
    {
        private RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate _next)
        {
            next= _next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode= 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { status = 500, message = ex.Message});
            }
        }
    }
}
