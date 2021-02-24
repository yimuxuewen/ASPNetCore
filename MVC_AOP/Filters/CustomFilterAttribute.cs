using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AOP.Filters
{
    public class CustomResultFilterAttribute : Attribute, IResultFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"This is {typeof(CustomResultFilterAttribute)} OnResultExecuted"); ;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"This is {typeof(CustomResultFilterAttribute)} OnResultExecuting"); ;
        }
    }


    public class CustomResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"This is {typeof(CustomResourceFilterAttribute)} OnResourceExecuted"); ;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"This is {typeof(CustomResourceFilterAttribute)} OnResourceExecuting"); ;
        }
    }
}
