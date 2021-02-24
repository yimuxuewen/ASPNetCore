using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Models
{
    public class CustomerExceptionAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result = new JsonResult(new
                {
                    msg = $"{context.Exception.Message}"
                });
            };
            context.ExceptionHandled = true;
        }
    }
}
