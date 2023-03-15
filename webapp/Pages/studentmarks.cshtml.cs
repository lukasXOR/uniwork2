using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoleAppProject.App03;
namespace webapp.Pages
{
    public class studentClass : PageModel
    {

        [BindProperty]
        public string studentName { get; set; }

        [BindProperty]
        public double studentMark { get; set; }
        public void OnPostCalculate()
        {
        }
    }
}