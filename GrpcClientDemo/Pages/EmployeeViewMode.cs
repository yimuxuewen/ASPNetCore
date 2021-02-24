using GrpcClientDemo.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcClientDemo.Pages
{
    public class EmployeeViewMode : ComponentBase
    {
        [Parameter]
        public string DepartmentId { get; set; }

        public IEnumerable<GrpcDemo.Protos.Employee> employees;

        [Inject]
        public IEmployeeService employeeService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            employees = await employeeService.GetEmployees(int.Parse(DepartmentId));
        }
    }
}
