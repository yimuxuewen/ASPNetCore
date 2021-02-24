using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPageTest.Models;
using RazorPageTest.Services;

namespace RazorPageTest
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            //var cf = configuration["ControllerViewtest:BoldDepartmentEmployeeCountThreshold"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.Configure<CustomerOptions>(_configuration.GetSection("ControllerViewtest"));

            services.AddCors((c=>
            {
                c.AddPolicy("LimitRequests", policy =>
                 {
                     policy.WithOrigins("http://localhost:5005", "http://l27.0.0.1:5005")
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                 });
            }));
        }

        public void  ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterModule<CustomerAutofacModule>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                //app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("LimitRequests");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages().RequireCors("LimitRequests");
            });
        }
    }
}
