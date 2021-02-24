using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AOP.Filters
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order {get;set;}

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This is {typeof(CustomActionFilterAttribute)} OnActionExecuted"); ;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This is {typeof(CustomActionFilterAttribute)} OnActionExecuting"); ;
        }
    }

    public class CustomControllerFilterAttribute : Attribute, IActionFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This is {typeof(CustomControllerFilterAttribute)} OnControllerExecuted"); ;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This is {typeof(CustomControllerFilterAttribute)} OnControllerExecuting"); ;
        }
    }

    public class CustomGlobalFilterAttribute : Attribute, IActionFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This is {typeof(CustomGlobalFilterAttribute)} OnGlobalExecuted"); ;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This is {typeof(CustomGlobalFilterAttribute)} OnGlobalExecuting"); ;
        }
    }

}
