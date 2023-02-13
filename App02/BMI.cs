
using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class BMI
    {
        public void run() {
            Console.WriteLine("BMI Calculator");
            string[] menuOptions = {"imperial stones/pounds feet/inches", "metric kg metres"};
            double optionUnit = Utility.CreateOption("unit?", "menu", menuOptions);
            string[] info = menuOptions[(int)optionUnit].Split(" ");
            double optionWeight = Utility.CreateOption("enter weight " + info[1], "input", new string[0]);
            Console.WriteLine();
            double optionHeight = Utility.CreateOption("enter height " + info[2], "input", new string[0]);
            Utility.CleanConsole();
            double userBMI = 0;
            switch (optionUnit) {
                case 1:
                    userBMI = (optionWeight * 703) / Math.Pow(optionHeight, 2);
                    break;
                case 2:
                    userBMI = optionWeight / Math.Pow(optionHeight, 2);
                    break;
            }

            Console.Write("BMI" + Math.Round(userBMI, 4) + " ");

            if (userBMI < 18.5)
                Console.WriteLine(Unit.Underweight);
            else if (userBMI > 18.5 && userBMI < 24.9)
                Console.WriteLine(Unit.Normal);
            else if (userBMI > 25 && userBMI < 29.9)
                Console.WriteLine(Unit.Overweight);
            else if (userBMI > 30 && userBMI < 34.9)
                Console.WriteLine(Unit.ObeseI);
            else if (userBMI > 35.0 && userBMI < 39.9)
                Console.WriteLine(Unit.ObeseII);
            else if (userBMI > 40.0)
                Console.WriteLine(Unit.ObeseIII);
        }
    }
}
