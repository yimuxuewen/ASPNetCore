using RazorPageTest.Models;
using RazorPageTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.ViewComponents
{
    public class CompanySummaryViewComponent : ViewComponent
    {
        private readonly IDepartmentService _department;

        public CompanySummaryViewComponent(IDepartmentService department)
        {
            _department = department;
        }

        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.Title = title;
            var summary =await _department.GetCompanySummary();
            return View(summary);
        }
    }
}
