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
            double from = 34;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToMetres()
        {
            double from = 52;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToYards()
        {
            double from = 20;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToInches()
        {
            double from = 83;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMilesToCentimetres()
        {
            double from = 11;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("miles", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToMiles()
        {
            double from = 67;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToMetres()
        {
            double from = 28;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToYards()
        {
            double from = 61;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToInches()
        {
            double from = 54;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestFeetToCentimetres()
        {
            double from = 16;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("feet", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToMiles()
        {
            double from = 14;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToFeet()
        {
            double from = 17;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToYards()
        {
            double from = 89;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToInches()
        {
            double from = 31;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestMetresToCentimetres()
        {
            double from = 58;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("metres", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToMiles()
        {
            double from = 49;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToFeet()
        {
            double from = 100;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToMetres()
        {
            double from = 14;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToInches()
        {
            double from = 81;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "inches", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestYardsToCentimetres()
        {
            double from = 25;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("yards", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToMiles()
        {
            double from = 90;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToFeet()
        {
            double from = 95;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToMetres()
        {
            double from = 45;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToYards()
        {
            double from = 84;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestInchesToCentimetres()
        {
            double from = 20;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("inches", "centimetres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToMiles()
        {
            double from = 95;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "miles", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToFeet()
        {
            double from = 62;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "feet", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToMetres()
        {
            double from = 83;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "metres", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToYards()
        {
            double from = 79;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "yards", from);

            Assert.AreEqual(to, conversion);
        }

        [TestMethod]
        public void TestCentimetresToInches()
        {
            double from = 50;

            double to = 0.145; //expected 

            double conversion = ConvertUnit("centimetres", "inches", from);

            Assert.AreEqual(to, conversion);
        }

    }
}
var text = ''
var units = ["Miles", "Feet", "Metres", "Yards", "Inches", "Centimetres"]
for (var i = 0; i < units.length; i++) {
    for (var j = 0; j < units.length; j++)
    {
        if (units[i] == units[j])
            continue;
        var ran = Math.floor(Math.random() * 100) + 10
        text += `
        [TestMethod]
        public void Test${units[i] + "To" + units[j]} () {
            double from = ${ran};

            double to = 0.145; //expected 

            double conversion = ConvertUnit("${units[i].toLowerCase()}", "${units[j].toLowerCase()}", from);

            Assert.AreEqual(to, conversion);
        }
            `
    }
}
console.log(text)
