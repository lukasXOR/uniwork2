using System;
namespace ConsoleAppProject {
    public class Program {
        public static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine("=================================================");
            Console.WriteLine("by lukas");
            while (true)
                Utility.CreateMainMenu(Utility.GetMenuOptions());
        }
    }
}
