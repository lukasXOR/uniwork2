using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoleAppProject.App02;
namespace webapp.Pages
{
    public class bmicalculatorModel : PageModel
    {
        public new BMI calculator = new BMI();

        [BindProperty]
        public string UnitSystem { get; set; }

        [BindProperty]
        public double UserWeight { get; set; }

        [BindProperty]
        public double UserHeight { get; set; }


        public string output;
        public void OnPostCalculate()
        {
            output = calculator.CalculateBMI(UnitSystem == "imperial" ? 0 : 1, UserWeight, UserHeight);
        }
    }
}
