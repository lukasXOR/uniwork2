using System;
using System.Net.Sockets;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// The app will calculate BMI
    /// </summary>
    /// <author>
    /// lukas
    public class BMI
    {
        public string programDesc = "BMI Calculator";
        public string[] menuOptions = { "imperial pounds inches", "metric kg metres" };
        public void run()
        {
            double optionUnit = Utility.CreateOption("unit?", "menu", menuOptions);
            string[] info = menuOptions[(int)optionUnit].Split(" ");
            double optionWeight = Utility.CreateOption("enter weight in " + info[1], "input", new string[0]);
            double optionHeight = Utility.CreateOption("enter height in " + info[2], "input", new string[0]);
            Console.Write(optionWeight + " " + info[1] + " " + optionHeight + " " + info[2]);
            CalculateBMI((int)optionUnit, optionWeight, optionHeight);
            DisplayWeightTable();
        }
        /// <summary>
        /// Calculate the BMI, round it to 4 decimal places, class it under the WHO
        /// regulations and display it.
        /// </summary>
        /// <param name="unit">The unit to be used for calculation</param>
        /// <param name="weight">The users weight</param>
        /// <param name="height">The users height</param>
        /// <returns>A string which will be a message containg the users BMI and the class
        /// which will be for the web app
        /// </returns>
        public string CalculateBMI(int unit, double weight, double height)
        {
            double userBMI = (unit == 0 ? weight * 703 : weight) / Math.Pow(height, 2);

            Unit userCategory = Unit.Underweight;

            if (userBMI < 18.5) userCategory = Unit.Underweight;
            else if (userBMI >= 18.5 && userBMI < 25) userCategory = Unit.Normal;
            else if (userBMI >= 25 && userBMI < 30) userCategory = Unit.Overweight;
            else if (userBMI >= 30 && userBMI < 35) userCategory = Unit.ObeseI;
            else if (userBMI >= 35 && userBMI < 40) userCategory = Unit.ObeseII;
            else if (userBMI >= 40) userCategory = Unit.ObeseIII;

            string webappOutput = "Your BMI is " + Math.Round(userBMI, 4) + " classed at: " + userCategory;;

            Console.WriteLine(" is " + Math.Round(userBMI, 4) + " Classed at: " + userCategory);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("note that you should assume these values are inaccurate if");
            Console.WriteLine("you are within minority ethnic groups (BAME) or that you are a");
            Console.WriteLine("child, pregnant or someone with a significant amount of muscle");
            Console.ForegroundColor = ConsoleColor.Cyan;

            return webappOutput;
        }
        /// <summary>
        /// Display all the WHO weight categories and output it in a table
        /// </summary>
        private void DisplayWeightTable()
        {
            string[] weightCategory = { "WHO Weight Status", "Underweight", "Normal", "Overweight", "Obese Class I", "Obese Class II", "Obese Class III" };
            string[] BMIRange = { "BMI (kg/m^2)", "<= 18.50", "18.5 - 24.9", "25.0 - 29.9", "30.0 - 34.9", "35.0 - 39.9", ">= 40.0" };

            int weightCategoryTitleLength = weightCategory[0].Length;
            int BMIRangeTitleLength = BMIRange[0].Length;

            for (int i = 0; i < weightCategory.Length; i++)
            {
                Console.Write('|' + weightCategory[i].PadRight(weightCategoryTitleLength));
                Console.Write('|' + BMIRange[i].PadRight(BMIRangeTitleLength));
                Console.WriteLine('|');
            }
        }
    }
}
