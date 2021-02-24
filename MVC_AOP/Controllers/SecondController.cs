using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_AOP.Filters;

namespace MVC_AOP.Controllers
{
    //[ResponseCache(Duration =60)]
    public class SecondController : Controller
    {
        private readonly IA _ia;

        public SecondController(IA ia)
        {
            _ia = ia;
        }

        //[CustomResourceFilter]
        //[CustomActionFilter]
        //[CustomResultFilter]
        //[CustomCacheResourceFilter]
        //[ResponseCache(Duration = 600)]//配合ResponseCaching 实现服务端缓存
        public IActionResult Index()
        {
            Console.WriteLine("This is Index");
            base.HttpContext.Response.Headers["Cache-Control"] = "public,max-age=600";
            ViewBag.Now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            ViewBag.ServerTime = _ia.PlusTime(-3).ToString("yyyy-MM-dd HH:mm:ss fff");
            return View();
        }
    }
}