using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// The app will convert units
    /// </summary>
    /// <author>
    /// lukas
    public class DistanceConverter 
    {
        public string programDescription = "Distance Converter";
        public string[] menuOptions = { "miles", "feet", "metres", "yards", "inches", "centimetres" };
        public void run()
        {
            double optionFrom = Utility.CreateOption("unit to convert from?", "menu", menuOptions);
            double optionTo = Utility.CreateOption(menuOptions[(int)optionFrom] + " to?", "menu", menuOptions);
            double input = Utility.CreateOption("enter " + menuOptions[(int)optionFrom], "display", menuOptions);
            ConvertUnit(menuOptions[(int)optionFrom], menuOptions[(int)optionTo], input);
        }
        /// <summary>
        /// Convert the units given, if the from and to unit are the same, then don't convert
        /// instead just output the value.
        /// </summary>
        /// <param name="from">The unit to be converted from</param>
        /// <param name="to">The unit to be converted to</param>
        /// <param name="input">The value to be converted</param>
        /// <returns>A double which will be the converted value which is returned for the web app.</returns>
        public double ConvertUnit(string from, string to, double input)
        {
            if (from.Equals(to))
            {
                Console.WriteLine(" " + from + " is " + input + " " + from);
                return input;
            }
            Console.Write(" is ");
            /* 
            getMethod() lets us find a function in a given class based on a string
            Invoke() lets us use that function which then we can call the conversion methods,
            you can pass arguments by giving it an object of parametres
            */
            Double convertedInput = (double)typeof(DistanceUnits).GetMethod(from + "_" + to).Invoke(this, new object[] { input });
            Console.Write(convertedInput);
            Console.WriteLine(" " + to);
            return convertedInput;
        }
    }
}
