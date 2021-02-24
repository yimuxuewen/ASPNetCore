using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AOP.Filters
{
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata, IOrderedFilter
    {
        private Dictionary<string, object> _CustomCacheResourceFilterAttributeDict = new Dictionary<string, object>();
        public int Order  => 0;

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string key = context.HttpContext.Request.Path;
            _CustomCacheResourceFilterAttributeDict.Add(key, context.Result);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string key = context.HttpContext.Request.Path;
            if (_CustomCacheResourceFilterAttributeDict.Keys.Contains(key))
            {
                context.Result = (IActionResult)_CustomCacheResourceFilterAttributeDict[key];
            };
        }
    }
}
