using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcDemo.GRpcServices;
using GrpcDemo.Repository;
using GrpcDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GrpcDemo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            //services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            //services.AddSingleton<IEmployeeRepository, EmployeeRpository>();
            //services.AddSingleton<ISummaryRpository, SummaryRpository>();
            services.AddDbContextPool<APPDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDepartmentRepository, DepartmentSQLRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeSQLRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DepartmentService>();
                endpoints.MapGrpcService<EmployeeService>();
            });
        }
    }
}
