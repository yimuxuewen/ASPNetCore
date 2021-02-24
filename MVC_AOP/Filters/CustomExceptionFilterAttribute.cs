using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AOP.Filters
{
    public class CustomExceptionFilterAttribute: ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger= logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                Console.WriteLine($"{context .HttpContext.Request.Path} {context.Exception.Message}");
                context.Result= new JsonResult(new
                {
                    Result = false,
                    Message="发生异常，请联系管理员"
                });
                _logger.LogError($"{context.HttpContext.Request.Path} {context.Exception.Message}");
                context.ExceptionHandled = true;
            }
        }
    }
}
 