using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App02;
using System;
namespace apptests
{
    [TestClass]
    public class BMICalculator
    {
        BMI calculator = new BMI();
        public double ConvertUnit(int unit, double weight, double height) {
            return Math.Round(calculator.CalculateBMI(unit, weight, height)); //round becauase of floating precision errors
        }
        [TestMethod]
        public void TestUnderweightMin()
        {

            double conversion = ConvertUnit(1, 45.5, 1.6);

            Assert.AreEqual(18, conversion);
        }

        [TestMethod]
        public void TestUnderweightMax()
        {

            double conversion = ConvertUnit(1, 68.2, 1.93);

            Assert.AreEqual(18, conversion);
        }

        [TestMethod]
        public void TestNormalMin()
        {

            double conversion = ConvertUnit(1, 45.5, 1.52);

            Assert.AreEqual(20, conversion);
        }

        [TestMethod]
        public void TestNormalMax()
        {

            double conversion = ConvertUnit(1, 90.9, 1.93);

            Assert.AreEqual(24, conversion);
        }

        [TestMethod]
        public void TestOverweightMin()
        {

            double conversion = ConvertUnit(1, 59.1, 1.52);

            Assert.AreEqual(26, conversion);
        }

        [TestMethod]
        public void TestOverweightMax()
        {

            double conversion = ConvertUnit(1, 97.7, 1.93);

            Assert.AreEqual(26, conversion);
        }

        [TestMethod]
        public void TestObeseIMin()
        {

            double conversion = ConvertUnit(1, 70.5, 1.52);

            Assert.AreEqual(31, conversion);
        }

        [TestMethod]
        public void TestObeseIMax()
        {

            double conversion = ConvertUnit(1, 88.6, 1.62);

            Assert.AreEqual(34, conversion);
        }

        [TestMethod]
        public void TestObeseIIMin()
        {

            double conversion = ConvertUnit(1, 93.2, 1.6);

            Assert.AreEqual(36, conversion);
        }

        [TestMethod]
        public void TestObeseIIMax()
        {

            double conversion = ConvertUnit(1, 97.7, 1.57);

            Assert.AreEqual(40, conversion);
        }

        [TestMethod]
        public void TestObeseIIIMin()
        {

            double conversion = ConvertUnit(1, 93.2, 1.52);

            Assert.AreEqual(40, conversion);
        }

        [TestMethod]
        public void TestObeseIIIMax()
        {

            double conversion = ConvertUnit(1, 97.7, 1.52);

            Assert.AreEqual(42, conversion);
        }



    }
}