using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// lukas
    /// </author>
    public class DistanceConverter
    {
        public static string createMenu(string[] msg)
        {
            for (int i = 0; i < msg.Length; i++)
            {
                Console.WriteLine(msg[i] + " " + (i + 1));
            }
            return Console.ReadLine();
        }
        public static string convertUnit(string from, string to, double input)
        {
            double userInput = input;
            double newValue = 0;
            //constants
            int mileFeet = 5280;
            double mileMetres = 1609.34;
            double feetMetres = 0.3048;
            switch (from)
            {
                case "miles":
                    if (to == "feet") newValue = userInput * mileFeet;
                    else if (to == "metres")  newValue = userInput * mileMetres;
                    break;
                case "feet":
                    if (to == "miles") newValue = userInput / mileFeet;
                    else if (to == "metres") newValue = userInput / feetMetres;
                    break;
                case "metres":
                    if (to == "feet")  newValue = userInput * feetMetres;
                    else if (to == "miles") newValue = userInput / mileMetres;
                    break;
            }
            Console.WriteLine(from + " " + input + " is " + newValue + " in " + to);
            return "";
        }
        public void run()
        {
            string[] menuOptions = {"miles", "feet", "metres" };

            Console.WriteLine("unit to convert from?");
            int optionFrom = int.Parse(createMenu(menuOptions)) - 1;

            Console.WriteLine("unit to convert to?");
            int optionTo = int.Parse(createMenu(menuOptions)) - 1;

            Console.WriteLine("enter " + menuOptions[optionFrom]);
            double input = Double.Parse(Console.ReadLine());

            convertUnit(menuOptions[optionFrom], menuOptions[optionTo], input);

        }
    }
}
