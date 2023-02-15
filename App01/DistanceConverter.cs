using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// The app will convert units
    /// </summary>
    /// <author>
    /// lukas
    public class DistanceConverter {
        // we will use the index of the array to create a numbered menu AND to take the users option
        public static string[] menuOptions = {"miles", "feet", "metres", "yards", "inches", "centimetres"};
        /*
        get needed inputs from user
        */
        public void run() {
            double optionFrom = Utility.CreateOption("unit to convert from?", "menu", menuOptions);
            double optionTo = Utility.CreateOption(menuOptions[(int)optionFrom] + " to?", "menu", menuOptions);
            double input = Utility.CreateOption("enter " + menuOptions[(int)optionFrom], "finput", menuOptions);
            ConvertUnit(menuOptions[(int)optionFrom], menuOptions[(int)optionTo], input);
        }
        public void ConvertUnit(string from, string to, double input) {
            if (from.Equals(to)) {
                Console.WriteLine(" " + from + " is " + input + " " + from);
                return;
            }
            Console.Write(" " + from + " is ");
            /* 
            getMethod() lets us find a function in a given class based on a string
            Invoke() lets us use that function which then we can call the conversion methods,
            you can pass arguments by giving it an object of parametres
            */
            Console.Write(typeof(DistanceUnits).GetMethod(from + "_" + to).Invoke(this, new object[]{input}));
            Console.WriteLine(" " + to);
        }
    }
}
