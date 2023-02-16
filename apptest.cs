using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;
using System;
namespace apptests
{
    [TestClass]
    public class DistanceConverterTests
    {
        DistanceConverter converter = new DistanceConverter();
        public double ConvertUnit(string from, string to, double conversion)
        {
            return Math.Round(converter.ConvertUnit(from, to, conversion), 3); //round becauase of floating precision errors
        }
        [TestMethod]
        public void TestMilesToFeet()
        {
            double from = 3;

            double to = 15840; //expected 

            double conversion = ConvertUnit("miles", "feet", from);

            Assert.AreEqual(to, conversion);
        }
        [TestMethod]
        public void TestFeetToMiles()
        {
            double from = 23456;

            double to = 4.442; //expected 

            double conversion = ConvertUnit("feet", "miles", from);

            Assert.AreEqual(to, conversion);
        }
        [TestMethod]
        public void TestMetresToMiles()
        {
            double from = 234;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "miles", from);

            Assert.AreEqual(to, conversion);
        }
    }
}
