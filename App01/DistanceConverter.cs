﻿using System;
namespace ConsoleAppProject.App01{
    /// <summary>
    /// The app will convert units
    /// </summary>
    /// <author>
    /// lukas
    /// </author>
    public class DistanceConverter {
        public static string[] menuOptions = {"miles", "feet", "metre", "yard", "inch", "centimetre"};
        /*
        get needed inputs from user
        */
        public void run() {
            double optionFrom = createOption("unit to convert from?", "menu");
            double optionTo = createOption("unit to convert to?", "menu");
            double input = createOption("enter " + menuOptions[(int)optionFrom], "input");
            convertUnit(menuOptions[(int)optionFrom], menuOptions[(int)optionTo], input);
        }

        public static string createMenu(string[] msg) {
            for (int i = 0; i < msg.Length; i++)
                Console.WriteLine((i + 1) + " " + msg[i]); // (i + 1) because we want the options to start with 1
            return Console.ReadLine();
        }

        public void convertUnit(string from, string to, double input) {
            Console.Write(input + " " + from + " is ");
            Console.Write(typeof(DistanceUnits).GetMethod(from + "_" + to).Invoke(this, new object[]{input}));
            Console.WriteLine(to);
        }
        /*
        retrieve inputs from user with creating a menu
        it can take a menu option and also an actual value
        */
        public static Double createOption(string input, string type) {
            Double option;
            do {
                try {
                    Console.WriteLine(input);
                    switch (type) {
                        case "menu": // create a menu
                            option = Double.Parse(createMenu(menuOptions));
                            if (option > menuOptions.Length) {
                                Console.Clear();
                                Console.WriteLine("Option provided is outside of menu range");
                                continue;
                            }
                            return option - 1;
                        case "input": // only need a response from the user
                            return Double.Parse(Console.ReadLine());
                    }
                } catch (System.FormatException) { // this will be caught if letters are detected
                    Console.Clear();
                    Console.WriteLine("Please enter a number according to the menu");
                    continue;
                }
            } while (true); // infinite loop (true = true), until the user inputs a valid option
        }
    }
}
