using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace API.Filters
{
    public class ActionTimeFilter:ActionFilterAttribute
    {
        Stopwatch _stopwatch;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["Stopwatch"] = Stopwatch.StartNew();
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sw = (Stopwatch)context.HttpContext.Items["Stopwatch"];
            sw.Stop();
            Console.WriteLine($"Timing {context.ActionDescriptor.DisplayName} Took : {sw.ElapsedMilliseconds}ms");
            base.OnActionExecuted(context);
        }
    }
}
