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
            return Math.Round(converter.ConvertUnit(from, to, conversion)); //round becauase of floating precision errors
        }

        [TestMethod]
        public void TestMilesToFeet()
        {
            double from = 34;

            double to = 179520; //expected 

            double conversion = ConvertUnit("miles", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToMetres()
        {
            double from = 52;

            double to = 83686; //expected 

            double conversion = ConvertUnit("miles", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToYards()
        {
            double from = 20;

            double to = 35200; //expected 

            double conversion = ConvertUnit("miles", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToInches()
        {
            double from = 0.5;

            double to = 31680; //expected 

            double conversion = ConvertUnit("miles", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToCentimetres()
        {
            double from = 5;

            double to = 804500; //expected 

            double conversion = ConvertUnit("miles", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToMiles()
        {
            double from = 8474;

            double to = 2; //expected 

            double conversion = ConvertUnit("feet", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToMetres()
        {
            double from = 321;

            double to = 98; //expected 

            double conversion = ConvertUnit("feet", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToYards()
        {
            double from = 61;

            double to = 20; //expected 

            double conversion = ConvertUnit("feet", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToInches()
        {
            double from = 54;

            double to = 648; //expected 

            double conversion = ConvertUnit("feet", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToCentimetres()
        {
            double from = 16;

            double to = 488; //expected 

            double conversion = ConvertUnit("feet", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToMiles()
        {
            double from = 12334;

            double to = 8; //expected 

            double conversion = ConvertUnit("metres", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToFeet()
        {
            double from = 17;

            double to = 56; //expected 

            double conversion = ConvertUnit("metres", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToYards()
        {
            double from = 89;

            double to = 97; //expected 

            double conversion = ConvertUnit("metres", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToInches()
        {
            double from = 31;

            double to = 1220; //expected 

            double conversion = ConvertUnit("metres", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToCentimetres()
        {
            double from = 58;

            double to = 5800; //expected 

            double conversion = ConvertUnit("metres", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToMiles()
        {
            double from = 3466;

            double to = 2; //expected 

            double conversion = ConvertUnit("yards", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToFeet()
        {
            double from = 100;

            double to = 300; //expected 

            double conversion = ConvertUnit("yards", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToMetres()
        {
            double from = 14;

            double to = 13; //expected 

            double conversion = ConvertUnit("yards", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToInches()
        {
            double from = 81;

            double to = 2916; //expected 

            double conversion = ConvertUnit("yards", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToCentimetres()
        {
            double from = 25;

            double to = 2286; //expected 

            double conversion = ConvertUnit("yards", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToMiles()
        {
            double from = 252555;

            double to = 4; //expected 

            double conversion = ConvertUnit("inches", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToFeet()
        {
            double from = 92349;

            double to = 7696; //expected 

            double conversion = ConvertUnit("inches", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToMetres()
        {
            double from = 234879;

            double to = 5966; //expected 

            double conversion = ConvertUnit("inches", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToYards()
        {
            double from = 842678;

            double to = 23408; //expected 

            double conversion = ConvertUnit("inches", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToCentimetres()
        {
            double from = 17504;

            double to = 44460; //expected 

            double conversion = ConvertUnit("inches", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToMiles()
        {
            double from = 28935772;

            double to = 180; //expected 

            double conversion = ConvertUnit("centimetres", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToFeet()
        {
            double from = 926784;

            double to = 30406; //expected 

            double conversion = ConvertUnit("centimetres", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToMetres()
        {
            double from = 728393;

            double to = 7284; //expected 

            double conversion = ConvertUnit("centimetres", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToYards()
        {
            double from = 627834;

            double to = 6866; //expected 

            double conversion = ConvertUnit("centimetres", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToInches()
        {
            double from = 34283;

            double to = 13497; //expected 

            double conversion = ConvertUnit("centimetres", "inches", from);

            Assert.AreEqual(to, conversion);
        }

    }
}