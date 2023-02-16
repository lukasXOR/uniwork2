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
        using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;
using System;
namespace apptests
{
    [TestClass]
    public class DistanceConverterTests
    {
        DistanceConverter converter = new DistanceConverter();
        public double ConvertUnit(string from, string to, double conversion) {
            return Math.Round(converter.ConvertUnit(from, to, conversion), 3); //round becauase of floating precision errors
        }
        [TestMethod]
        public void TestMilesToFeet()
        {
            double from = 164;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToMetres()
        {
            double from = 752;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToYards()
        {
            double from = 824;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToInches()
        {
            double from = 880;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToCentimetres()
        {
            double from = 1007;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToMiles()
        {
            double from = 670;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToMetres()
        {
            double from = 831;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToYards()
        {
            double from = 165;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToInches()
        {
            double from = 875;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToCentimetres()
        {
            double from = 1011;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToMiles()
        {
            double from = 963;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToFeet()
        {
            double from = 1068;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToYards()
        {
            double from = 324;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToInches()
        {
            double from = 891;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToCentimetres()
        {
            double from = 815;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToMiles()
        {
            double from = 956;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToFeet()
        {
            double from = 1043;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToMetres()
        {
            double from = 1099;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToInches()
        {
            double from = 1066;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToCentimetres()
        {
            double from = 770;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToMiles()
        {
            double from = 595;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToFeet()
        {
            double from = 307;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToMetres()
        {
            double from = 141;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToYards()
        {
            double from = 487;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToCentimetres()
        {
            double from = 182;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToMiles()
        {
            double from = 306;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToFeet()
        {
            double from = 1067;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToMetres()
        {
            double from = 311;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToYards()
        {
            double from = 784;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToInches()
        {
            double from = 519;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "inches", from);

            Assert.AreEqual(to, conversion);
        }

    }
}
    }
}
