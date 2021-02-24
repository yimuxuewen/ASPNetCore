using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageTest.Services;

namespace RazorPageTest.Pages.Employee
{
    public class AddEmployeeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public RazorPageTest.Models.Employee EmployeeModel { get; set; }
        public AddEmployeeModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> OnPostAsync(int departmentId)
        {
            EmployeeModel.DepartmentId = departmentId;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _employeeService.Add(EmployeeModel);
            return RedirectToPage("EmployeeList",new { departmentId});
        }

    }
}
