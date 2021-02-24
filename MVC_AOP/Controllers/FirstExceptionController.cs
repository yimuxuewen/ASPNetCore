using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_AOP.Filters;

namespace MVC_AOP.Controllers
{
    //[CustomExceptionFilterAttribute] //Controller注册
    //[ServiceFilter(typeof(CustomExceptionFilterAttribute))] //ConfigureServices中需要注册
    //[TypeFilter(typeof(CustomExceptionFilterAttribute))]//ConfigureServices中无需注册
    [CustomFilterFactoryAttribute(typeof(CustomExceptionFilterAttribute))]
    [CustomControllerFilter]
    public class FirstExceptionController : Controller
    {
        //[CustomExceptionFilterAttribute] //Action注册
        public IActionResult Index()
        {
            int i = 90;
            int j = i - i;
            int h = i / j;
            return View();
        }
        public IActionResult Info()
        {
            int i = 90;
            int j = i - i;
            int h = i / j;
            return View();
        }

        [CustomActionFilter]
        [CustomCacheResourceFilterAttribute]
        public IActionResult About()
        {
            Console.WriteLine("This is Action");
            return View();
        }
    }
}