using BlazorDemo.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Pages
{
    public class EmployeeViewMode : ComponentBase
    {
        [Parameter]
        public string DepartmentId { get; set; }

        public IEnumerable<Models.Employee> employees;

        [Inject]
        public IEmployeeService employeeService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            employees = await employeeService.GetEmployees(int.Parse(DepartmentId));
        }
    }
}
