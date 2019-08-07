using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorIsWorkingCorrectly()
        {
            string expectedMake = "Mazda";
            string expectedModel = "c6";
            double expectedFuelConsumption = 7;
            double expectedFuelCapacity = 70;

            Car car = new Car("Mazda", "c6", 7, 70);

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void TestIfMakeCanBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, "c6", 7, 70);
            });
        }

        [Test]
        public void TestIfMakeCanBeEmpty() //consider adding test for white spaces
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "c6", 7, 70);
            });
        }

        [Test]
        public void TestIfModelCanBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mazda", null, 7, 70);
            });
        }

        [Test]
        public void TestIfModelCanBeEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mazda", "", 7, 70);
            });
        }

        [Test]
        public void TestIfFuelConsumptionCanBeNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mazda", "c6", -5, 70);
            });
        }

        [Test]
        public void TestIfFuelConsumptionCanBeZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mazda", "c6", 0, 70);
            });
        }

        [Test]
        public void TestifFuelCapacityCanBeZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mazda", "c6", 10, 0);
            });
        }

        [Test]
        public void TestifFuelCapacityCanBeNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Mazda", "c6", 10, -10);
            });
        }

        [Test]
        public void TestIf_Refuel_IsWorkingCorrectly()
        {
            Car car = new Car("Mazda", "c6", 10, 70);

            car.Refuel(20);

            double expextedFuelAmount = 20;

            Assert.AreEqual(expextedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfTheFuelToRefuelCanBeNegative()
        {
            Car car = new Car("Mazda", "c6", 10, 70);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-10);
            });
        }

        [Test]
        public void TestRefuelWithZero()
        {
            Car car = new Car("Mazda", "c6", 10, 70);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void TestIfTheFuelToRefuelCanBiggerThanFuelCapacity()
        {
            Car car = new Car("Mazda", "c6", 10, 50);

            car.Refuel(60);

            double expextedFuelAmount = 50;

            Assert.AreEqual(expextedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfDriveIsWorkingCorrectly()
        {
            Car car = new Car("Mazda", "c6", 10, 70);

            car.Refuel(20);
            car.Drive(100);

            double expextedFuelAmount = 10;

            Assert.AreEqual(expextedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfDriveThrowsExceptionWhenNeedFuelIsMoreThanFuelAmount()
        {
            Car car = new Car("Mazda", "c6", 10, 70);

            car.Refuel(20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(300);
            });
        }
    }
}