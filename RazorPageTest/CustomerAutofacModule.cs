using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using RazorPageTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RazorPageTest
{
    public class CustomerAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = GetType().GetTypeInfo().Assembly;
            var containerBuilder = new ContainerBuilder();
            var manager = new ApplicationPartManager();
            manager.ApplicationParts.Add(new AssemblyPart(assembly));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            var feature = new ControllerFeature();
            manager.PopulateFeature(feature);
            builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            builder.RegisterTypes(feature.Controllers.Select(t => t.AsType()).ToArray()).PropertiesAutowired();

            containerBuilder.Register(c => new CustomAutofacAop());//aop注册
            containerBuilder.RegisterType<DepartmentService>().As<IDepartmentService>().SingleInstance().PropertiesAutowired();
            containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>().SingleInstance().PropertiesAutowired();
            containerBuilder.RegisterType<ChinaClock>().As<IClock>().SingleInstance().PropertiesAutowired();

            containerBuilder.RegisterType<A>().As<IA>().EnableInterfaceInterceptors();
        }
    }

    public class CustomAutofacAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"invocation.Methond={invocation.Method}");
            Console.WriteLine($"invocation.Arguments={string.Join(",", invocation.Arguments)}");
            invocation.Proceed();//继续执行
            Console.WriteLine($"方法{invocation.Method}执行完成了");
        }
    }

    public interface IA
    {
        void Show(int id, string name);
    }

    [Intercept(typeof(CustomAutofacAop))]
    public class A : IA
    {
        public void Show(int id, string name)
        {
            Console.WriteLine($"This is {id} _ {name}"); 
        }
    }

}
