using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AOP.Filters
{
    public class CustomFilterFactoryAttribute : Attribute, IFilterFactory
    {
        private readonly Type _type;

        public CustomFilterFactoryAttribute(Type type)
        {
            _type = type;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return (IFilterMetadata)serviceProvider.GetService(_type);
        }
    }
}
