using System.Reflection;
using log4net;
using ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;
using ActionExecutedContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;
using Volo.Abp.Users;
using Microsoft.AspNetCore.Identity;
using qwerty.Enttities;

namespace RentACar.API.Contract
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Log4NetActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILog _logger;
  
        public Log4NetActionFilterAttribute()
        {
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Info($"Executing {context.ActionDescriptor.DisplayName}");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                _logger.Error("An error occurred:", context.Exception);
            }
            _logger.Info($"Executed {context.ActionDescriptor.DisplayName}");
            base.OnActionExecuted(context);
        }

    }
}

