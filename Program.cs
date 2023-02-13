using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using System;
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
    public class Program
    {
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
        
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine("=================================================");
            Console.WriteLine("author: lukas");

            DistanceConverter converter = new DistanceConverter();
            converter.run();
            
            BMI bmi = new BMI();
            //bmi.run();
        }
    }
}
