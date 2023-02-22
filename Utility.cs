using System;
using System.Reflection;
namespace ConsoleAppProject {
    public class Utility
    {
        /* 
        This will let us override previous and the current line of the terminal
        to let outputs look cleaner. It works by going through each line of the
        terminal and cleaning it until it goes back to the 4th line. The 5th line
        is where the main headers are for the terminal so thats where we stop.
        */
        public static void CleanConsole() {
            while (Console.CursorTop > 4) {
                Console.CursorTop -= 1;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.BufferWidth - 1) + "\r");
            }
        }
        /* 
        Create numbered menu
        */
        public static string CreateMenu(string[] msg) {
            for (int i = 0; i < msg.Length; i++)
                // (i + 1) because we want the options to start with 1
                Console.WriteLine((i + 1) + " " + msg[i]);
            return Console.ReadLine();
        }
        /*
        Retrieve inputs from user with creating a menu
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
                            if (option > menu.Length || option == 0) {
                                Console.WriteLine("Option provided is outside of menu range");
                                continue;
                            }
                            return option - 1;
                        case "input":
                            option = Double.Parse(Console.ReadLine());
                            CleanConsole();
                            return option;
                        case "display":
                            // get the input and then go back to that position
                            // we can display the answer after it
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
            } while (true); // infinite loop (true == true), until the user inputs a valid option
        }
        /* 
        This lets us find a class by a string, it works by first fetching the assembly,
        the assembly is the compiled file (dll, exe) that contains everything needed to run
        the program, we are using it here to get all the classes. We first get the assembly by
        using any class in the program with the GetTypeInfo(), which returns a TypeInfo which is just
        an extension of Type that contains the assembly (.Assembly). From here we create and 
        filter an array by the string of the class name we want to fetch by all the compiled classes.
        */
        public static Type[] GetType(string type) {
            Assembly a = typeof(Program).GetTypeInfo().Assembly;
            return Array.FindAll(a.GetTypes(), c => c.ToString().Contains(type));
        }
        /* 
        Fetch all class names to create the main menu, then reverse them because the assembly
        gives us the classes in the wrong order
        */
        public static string[] GetMenuOptions() {
            Type[] t = GetType("App0");
            string[] options = new string[t.Length];
            for (var (i, x) = (t.Length - 1, 0); i >= 0; i--, x++) {
                options[x] = t[i].Name; 
            }
            return options;
        }
        /* 
        Get the program the user wants to use and instantiate it.
        */
        public static void CreateMainMenu(string[] menuOptions) {
            CleanConsole();
            double option = CreateOption("Program to run: ", "menu", menuOptions);
            Type t = GetType(menuOptions[(int)option])[0];

            // we use the dynamic data type because we don't know what class to use until file compilation
            dynamic d = Activator.CreateInstance(t);

            Console.WriteLine(d.programDesc);
            d.run();

            Console.Write("Enter to restart");
            Console.ReadLine();
        }
    }
}
