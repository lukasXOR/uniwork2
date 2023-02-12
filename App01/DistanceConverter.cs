using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// The app will convert units
    /// </summary>
    /// <author>
    /// lukass
    public class DistanceConverter {
        // we will use the index of the array to create a numbered menu AND to take the users option
        public static string[] menuOptions = {"miles", "feet", "metres", "yards", "inches", "centimetres"};
        /*
        get needed inputs from user
        */
        public void run() {
            double optionFrom = CreateOption("unit to convert from?", "menu");
            CleanConsole();
            double optionTo = CreateOption(menuOptions[(int)optionFrom] + " to?", "menu");
            double input = CreateOption("enter " + menuOptions[(int)optionFrom], "input");
            ConvertUnit(menuOptions[(int)optionFrom], menuOptions[(int)optionTo], input);
        }
        public static void CleanConsole() {
            while (Console.CursorTop != 4) {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.BufferWidth) + "\r");
                Console.CursorTop -= 1;
            }
            Console.Write(new string(' ', Console.BufferWidth) + "\r");
        }
        public static string CreateMenu(string[] msg) {
            for (int i = 0; i < msg.Length; i++)
                Console.WriteLine((i + 1) + " " + msg[i]); // (i + 1) because we want the options to start with 1

            return Console.ReadLine();
        }
        public void ConvertUnit(string from, string to, double input) {
            if (from.Equals(to)) {
                Console.WriteLine(input + " " + from + " is " + input + " " + from);
                Environment.Exit(0);
            }
            Console.Write(input + " " + from + " is ");
            /* 
            getMethod() lets us find a function in a given class based on a string
            Invoke() lets us use that function which then we can call the conversion methods,
            you can pass arguments by giving it an object of parametres
            */
            Console.Write(typeof(DistanceUnits).GetMethod(from + "_" + to).Invoke(this, new object[]{input}));
            Console.WriteLine(to);
        }
        /*
        retrieve inputs from user with creating a menu
        it can take a menu option and also an actual value
        */
        public static Double CreateOption(string input, string type) {
            Double option;
            do {
                try {
                    Console.WriteLine(input);
                    switch (type) {
                        case "menu":
                            option = Double.Parse(CreateMenu(menuOptions));
                            if (option > menuOptions.Length) {
                                Console.Clear();
                                Console.WriteLine("Option provided is outside of menu range");
                                continue;
                            }
                            return option - 1;
                        case "input":
                            return Double.Parse(Console.ReadLine());
                    }
                } catch (FormatException) { // this will be caught if letters are detected
                    Console.Clear();
                    Console.WriteLine("Please enter a number according to the menu");
                    continue;
                }
            } while (true); // infinite loop (true = true), until the user inputs a valid option
        }
    }
}
