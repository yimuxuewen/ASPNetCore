using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageTest.Models;

namespace RazorPageTest.Pages
{
    [CustomerExceptionAttribute]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
