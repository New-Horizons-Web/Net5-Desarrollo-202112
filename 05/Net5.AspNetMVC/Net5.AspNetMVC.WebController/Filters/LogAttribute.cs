using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Net5.AspNetMVC.WebController.Filters
{
    public class LogAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
        }
    }
}
