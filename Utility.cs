using System;
//All these methods will be used in all the apps
namespace ConsoleAppProject {
    public class Utility {
        /* 
        This will let us override previous and the current line of the terminal
        to let outputs look cleaner
        */
        public static void CleanConsole() {
            while (Console.CursorTop != 5) {
                Console.CursorTop -= 1;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth) + "\r");
            }
            Console.Write(new string(' ', Console.WindowWidth) + "\r");
        }
        /* 
        Create numbered menu
        */
        public static string CreateMenu(string[] msg) {
            for (int i = 0; i < msg.Length; i++)
                Console.WriteLine((i + 1) + " " + msg[i]); // (i + 1) because we want the options to start with 1
            return Console.ReadLine();
        }
        /*
        retrieve inputs from user with creating a menu
        it can take a menu option and also an actual value
        */
        public static Double CreateOption(string input, string type, string[] menu) {
            Double option;
            do {
                try {
                    Console.WriteLine(input);
                    switch (type) {
                        case "menu":
                            option = Double.Parse(CreateMenu(menu));
                            CleanConsole();
                            if (option > menu.Length) {
                                Console.WriteLine("Option provided is outside of menu range");
                                continue;
                            }
                            return option - 1;
                        case "input":
                            string s = Console.ReadLine();
                            Console.CursorTop--;
                            Console.CursorLeft = s.Length;
                            return Double.Parse(s);
                    }
                } catch (FormatException) { // this will be caught if letters are detected
                    CleanConsole();
                    Console.WriteLine("Please enter a number according to the menu");
                    continue;
                }
            } while (true); // infinite loop (true = true), until the user inputs a valid option
        }
    }
}