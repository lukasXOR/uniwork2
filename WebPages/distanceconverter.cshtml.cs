using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoleAppProject.App01;
namespace webapp.Pages
{
    public class distanceconverterModel : PageModel
    {   
        public new DistanceConverter converter = new DistanceConverter();

        public string Conversion { get; set; }
        
        [BindProperty]
        public string FromUnit { get; set; }

        [BindProperty]
        public string ToUnit { get; set; }

        [BindProperty]
        public double ConversionValue { get; set; }
        
        public void OnPostConvert() {
            Conversion = ConversionValue + " "+ FromUnit + " is " + converter.ConvertUnit(FromUnit, ToUnit, ConversionValue) + " in " + ToUnit;
        }
    }
}
