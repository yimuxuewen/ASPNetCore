using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageTest.Services;

namespace RazorPageTest.Pages.Department
{
    public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentService _departmenService;

        [BindProperty]
        public RazorPageTest.Models.Department Departmentmodel { get; set; }

        public AddDepartmentModel(IDepartmentService departmenService)
        {
            _departmenService = departmenService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _departmenService.Add(Departmentmodel);
            return RedirectToPage("/Index");
        }
    }
}
