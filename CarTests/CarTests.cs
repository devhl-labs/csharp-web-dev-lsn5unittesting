using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNS;
using System;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        //TODO: add emptyTest so we can configure our runtime environment (remove this test before pushing to your personal GitHub account)
        [TestMethod]
        public void EmptyTest()
        {
            Assert.AreEqual(10, 10, .001);
        }

        private Car _testCar;

        [TestInitialize]
        public void CreateCarObject()
        {
            _testCar = new Car("Toyota", "Prius", 10, 50);
        }

        //TODO: constructor sets gasTankLevel properly
        [TestMethod]
        public void TestInitialGasTank()
        {
            Assert.AreEqual(10, _testCar.GasTankLevel, .001);
        }

        //TODO: gasTankLevel is accurate after driving within tank range
        [TestMethod]
        public void TestGasAfterDriving()
        {
            _testCar.Drive(50);

            Assert.AreEqual(9, _testCar.GasTankLevel, .001);
        }



        //TODO: gasTankLevel is accurate after attempting to drive past tank range
        [TestMethod]
        public void TestGasTankAfterExceeingTankRange()
        {
            double odometerStart = _testCar.Odometer;

            double tooManyMilesToDrive = 1000;

            _testCar.Drive(tooManyMilesToDrive);

            Assert.IsTrue(_testCar.Odometer < odometerStart + tooManyMilesToDrive);
        }



        //TODO: can't have more gas than tank size, expect an exception
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGasOverfillException()
        {
            _testCar.AddGas(5);
            Assert.Fail("Shouldn't get here, car cannot have more gas in tank than the size of the tank");
        }



    }
}
