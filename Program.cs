using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using System;
using System.Reflection;
namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Derek Peacock 05/02/2022
    /// </summary>
    public class Program {
        public static string[] menu;
        public static Assembly a = typeof(Program).GetTypeInfo().Assembly;
        public static void Main(string[] args) {
            menu = getAllOptions();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine("=================================================");
            while (true)
                CreateMainMenu(menu);
        }
        public static string[] getAllOptions() {
            Type[] t = Array.FindAll(a.GetTypes(), c => c.ToString().Contains("App0"));
            string[] options = new string[t.Length];
            for (var (i, x) = (t.Length - 1, 0); i >= 0; i--, x++) {
                options[x] = t[i].Name; 
            }
            return options;
        }
        public static void CreateMainMenu(string[] menuOptions) {
            double option = Utility.CreateOption("Program to run", "menu", menu);
            Type[] t = Array.FindAll(a.GetTypes(), c => c.ToString().Contains(menu[(int)option]));
            for (int i = 0; i < t.Length; i++) {
                dynamic d = Activator.CreateInstance(t[i]);
                d.run();
            }
        }
    }
}
