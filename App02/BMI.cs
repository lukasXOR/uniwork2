
using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class BMI
    {
        public void run()
        {
            Console.WriteLine("enter weight in kg");
            double usrWeight = Double.Parse(Console.ReadLine());

            Console.WriteLine("height in metres");
            double usrHeight = Math.Pow(Double.Parse(Console.ReadLine()), 2);

            double usrBMI = usrWeight / usrHeight;
            Console.Write(Math.Round(usrBMI, 4) + " ");

            if (usrBMI < 18.5)
                Console.WriteLine("underweight");
            else if (usrBMI > 18.5 && usrBMI < 24.9)
                Console.WriteLine("normal");
            else if (usrBMI > 25 && usrBMI < 29.9)
                Console.WriteLine("overweight");
            else if (usrBMI > 30 && usrBMI < 34.9)
                Console.WriteLine("obese class I");
            else if (usrBMI > 35.0 && usrBMI < 39.9)
                Console.WriteLine("obese class II");
            else if (usrBMI > 40.0)
                Console.WriteLine("obese class III");
        }
    }
}
