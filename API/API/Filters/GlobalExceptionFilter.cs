using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new
            {
                status = 500,
                message = context.Exception.Message
            })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
                
         }
    }
}
    