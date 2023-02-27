using System;
using System.Reflection;
namespace ConsoleAppProject {
    public class Utility
    {

        /// <summary>
        /// This will clean every line of the console all the way back to the
        /// original headers of the program. There are 4 lines of headers when
        /// the program starts. So we keep looping until were back to the 4th line
        /// of clearing.
        /// </summary>
        public static void CleanConsole() {
            while (Console.CursorTop > 4) {
                Console.CursorTop -= 1;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.BufferWidth - 1) + "\r");
            }
        }
        /// <summary>
        /// Creates a numbered menu
        /// </summary>
        /// <param name="messageOptions">An array containing options for the user to select.</param>
        /// <returns>The users input</returns>
        public static string CreateMenu(string[] messageOptions) {
            for (int i = 0; i < messageOptions.Length; i++)
                // (i + 1) because we want the options to start with 1
                Console.WriteLine((i + 1) + " " + messageOptions[i]);
            return Console.ReadLine();
        }
        /// <summary>
        /// Get inputs from the user, whether its from a menu, prompt or by the console line.
        /// </summary>
        /// <param name="messagePrompt">A string that the user sees first a message</param>
        /// <param name="type">The type of input that will be needed from the user</param>
        /// <returns>A double that will be a menu option or a number that is from a prompt</returns>
        /// <exception cref="FormatException">
        /// When the option contains letters
        /// </exception>
        public static Double CreateOption(string messagePrompt, string type, string[] menu) {
            Double option;
            do {
                try {
                    Console.WriteLine(messagePrompt);
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
                } catch (FormatException) {
                    CleanConsole();
                    Console.WriteLine("Please enter a number according to the menu");
                    continue;
                }
            } while (true); // infinite loop (true == true), until the user inputs a valid option
        }

        /// <summary>
        /// This lets us find a class by a string, it works by first fetching the assembly,
        /// the assembly is the compiled file (dll, exe) that contains everything needed to run
        /// the program, we are using it here to get all the classes. We first get the assembly by
        /// using any class in the program with the GetTypeInfo(), which returns a TypeInfo which is just
        /// an extension of Type that contains the assembly (.Assembly). From here we create and
        /// filter an array by the string of the class name we want ot fetch by all the compiles classes.
        /// </summary>
        /// <param name="type">Name of program.</param>
        /// <returns>An array containing the type of the desired program</returns>
        public static Type[] GetType(string type) {
            Assembly programAssembly = typeof(Program).GetTypeInfo().Assembly;
            return Array.FindAll(programAssembly.GetTypes(), programClass => programClass.ToString().Contains(type));
        }
        /// <summary>
        /// Fetch all the classes names that have 'App0' in them
        /// as the programs go from App01, App02 etc. Then put them in
        /// an array in reverse order because GetType() will give us
        /// a list of the classes going from last to first.
        /// </summary>
        public static string[] GetMenuOptions() {
            Type[] appNames = GetType("App0");
            string[] options = new string[appNames.Length];
            for (var (i, x) = (appNames.Length - 1, 0); i >= 0; i--, x++) {
                options[x] = appNames[i].Name;
            }
            return options;
        }
        /// <summary>
        /// Create a menu for the user to select their option
        /// then start that program by instantiating an object
        /// of that programs class
        /// </summary>
        /// <param name="menuOptions">
        /// An array of all the program names
        /// </param> 
        public static void CreateMainMenu(string[] menuOptions) {
            CleanConsole();
            double option = CreateOption("Program to run: ", "menu", menuOptions);
            Type optionType = GetType(menuOptions[(int)option])[0];

            // we use the dynamic data type because we don't know what class to use until file compilation
            dynamic programObject = Activator.CreateInstance(optionType);

            Console.WriteLine(programObject.programDesc);
            programObject.run();

            Console.Write("Enter to restart");
            Console.ReadLine();
        }
    }
}
