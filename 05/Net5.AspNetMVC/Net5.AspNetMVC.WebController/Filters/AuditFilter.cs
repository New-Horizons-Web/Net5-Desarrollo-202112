using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Net5.AspNetMVC.WebController.Filters
{
    public class AuditFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;
        public AuditFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AuditFilter>();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("OnActionExecuting");
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("OnActionExecuted");
            base.OnActionExecuted(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("OnActionExecuted");
            base.OnResultExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("OnActionExecuted");
            base.OnResultExecuted(context);
        }
    }
}
