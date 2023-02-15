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
        public static void Main(string[] args) {
            Type[] programClasses = getTypes();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine("=================================================");
        }
        public static Type[] getTypes() {
            Assembly a = typeof(Program).GetTypeInfo().Assembly;
            return Array.FindAll(a.GetTypes(), c => c.ToString().Contains("App0"));;
        }
        public static void CreateMainMenu(Type[] allClass) {
            Assembly a = typeof(Program).GetTypeInfo().Assembly;
            Type[] t = a.GetTypes();
            for (int i = t.Length - 1; i > 0; i--) {
                string className = t[i].ToString();
                if (className.Contains("App0")) {
                    Console.WriteLine(className);
                }
                if (t[i].Name.Equals("DistanceConverter")) {
                    dynamic d = Activator.CreateInstance(t[i]);
                    d.run();
                }
            }
        }
    }
}
