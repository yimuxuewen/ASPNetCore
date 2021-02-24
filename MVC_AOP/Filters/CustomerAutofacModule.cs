using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVC_AOP.Filters
{
    public class CustomerAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var builder = new ContainerBuilder();
            var manager = new ApplicationPartManager();
            manager.ApplicationParts.Add(new AssemblyPart(assembly));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            var feature = new ControllerFeature();
            manager.PopulateFeature(feature);
            builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            builder.RegisterTypes(feature.Controllers.Select(t => t.AsType()).ToArray()).PropertiesAutowired();

            containerBuilder.Register(c => new CustomAutofacAop());//aop注册
            containerBuilder.RegisterType<A>().As<IA>().SingleInstance().EnableInterfaceInterceptors();
        }
    }

    public class CustomAutofacAop : IInterceptor
    {
        Dictionary<string, object> _CustomAutofacAopDict = new Dictionary<string, object>();

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"invocation.Methond={invocation.Method}");
            Console.WriteLine($"invocation.Arguments={string.Join(",", invocation.Arguments)}");
            string key = $"invocation.Arguments={string.Join(",", invocation.Arguments)}";
            if (_CustomAutofacAopDict.Keys.Contains(key))
            {
                invocation.ReturnValue = _CustomAutofacAopDict[key];
            }
            else
            {
                invocation.Proceed();//继续执行
                _CustomAutofacAopDict.Add(key, invocation.ReturnValue);
            }
            Console.WriteLine($"方法{invocation.Method}执行完成了");
        }
    }

    public interface IA
    {
        void Show(int id, string name);

        DateTime PlusTime(int days);
    }

    [Intercept(typeof(CustomAutofacAop))]
    public class A : IA
    {
        public DateTime PlusTime(int days)
        {
            return DateTime.Now.AddDays(days);
        }

        public void Show(int id, string name)
        {
            Console.WriteLine($"This is {id} _ {name}");
        }
    }

}
