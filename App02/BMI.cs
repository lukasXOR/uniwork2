﻿using System;
using System.Data;
using System.Linq;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// The app will calculate BMI
    /// </summary>
    /// <author>
    /// lukas
    public class BMI {
        public string programDesc = "BMI Calculator";
        public string[] menuOptions = { "imperial stones/pounds feet/inches", "metric kg metres" };
        /*
        get needed inputs from users
        */
        public void run() {
            double optionUnit = Utility.CreateOption("unit?", "menu", menuOptions);
            string[] info = menuOptions[(int)optionUnit].Split(" ");
            double optionWeight = Utility.CreateOption("enter weight " + info[1], "input", new string[0]);
            double optionHeight = Utility.CreateOption("enter height " + info[2], "display", new string[0]);
            CalculateBMI((int)optionUnit, optionWeight, optionHeight);
        }
        /*
        calculate, round, class and display the BMI score
        */
        public double CalculateBMI(int unit, double weight, double height) {
            double userBMI = (unit == 0 ? weight * 703 : weight) / Math.Pow(height, 2);
            Console.Write(" is " + Math.Round(userBMI, 4) + " Classed at: ");
            if (userBMI < 18.5) Console.WriteLine(Unit.Underweight);
            else if (userBMI >= 18.5 && userBMI < 24.9) Console.WriteLine(Unit.Normal);
            else if (userBMI >= 25 && userBMI < 29.9) Console.WriteLine(Unit.Overweight);
            else if (userBMI >= 30 && userBMI < 34.9) Console.WriteLine(Unit.ObeseI);
            else if (userBMI >= 35.0 && userBMI < 39.9) Console.WriteLine(Unit.ObeseII);
            else if (userBMI >= 40.0) Console.WriteLine(Unit.ObeseIII);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("note that you should assume these values are inaccurate if");
            Console.WriteLine("you are within minority ethnic groups (BAME) or that you are a");
            Console.WriteLine("child, pregnant or someone with a signigicant amount of muscle");
            Console.ForegroundColor = ConsoleColor.Cyan;
            DisplayTable();
            return Math.Round(userBMI, 4);
        }
        /*
        display all the WHO weight categories. output it in a table. 
        */
        public string DisplayTable() {
            string[] weightCategory = {"WHO Weight Status", "Underweight", "Normal", "Overweight", "Obese Class I", "Obese Class II", "Obese Class III" };
            string[] BMIRange = {"BMI kg/m2", "18.50", "18.5 - 24.9", "25.0 - 29.9", "30.0 - 34.9", "35.0 - 39.9", ">= 40.0" };

            int longestWeightCategoryLength = weightCategory.Max(lengths => lengths.Length);
            int longestBMIRangeLength = BMIRange.Max(lengths => lengths.Length);

            for (int i = 0; i < weightCategory.Length; i++) {
                Console.Write("|");
                Console.Write(weightCategory[i].PadRight(longestWeightCategoryLength));
                Console.Write("|");
                Console.Write(BMIRange[i].PadRight(longestBMIRangeLength));
                Console.WriteLine("|");
            }
            return "";

        }
    }
}
