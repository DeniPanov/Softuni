namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;        

        [SetUp]
        public void Setup()
        {
            softPark = new SoftPark();
        }

        [Test]
        public void TestIfConstructorIsWorkingCorrectly()
        {
            Assert.IsNotNull(softPark);
        }

        [Test]
        public void TestIfCountIsWorkingCorrectly()
        {
            int expectedCount = 12;

            Assert.AreEqual(expectedCount, softPark.Parking.Count);
        }

        [Test]
        public void TestIf_ParkCar_IsWorkingCorrectly()
        {
            Car car = new Car("BMW", "7777");

            string expected = softPark.ParkCar("A1", car);
            var actual = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIfParkingSpotExists()
        {
            string invalidSpot = "C#";

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar(invalidSpot, null);
            });
        }

        [Test]
        public void TestIfTheSpotIsAlreadyTaken()
        {
            Car car = new Car("BMW", "7777");
            Car anotherCar = new Car("Mercedes", "8888");

            softPark.ParkCar("A2", car);

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar("A2", anotherCar);
            });
        }

        [Test]
        public void TestIfCarAlreadyExists()
        {
            Car car = new Car("BMW", "7777");

            softPark.ParkCar("A2", car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                softPark.ParkCar("B3", car);
            });
        }

        [Test]
        public void TestIf_RemoveCar_IsWorkingCorrectly()
        {
            Car car = new Car("BMW", "7777");
            softPark.ParkCar("A3", car);

            var expected = softPark.RemoveCar("A3", car);
            var actual = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void _RemoveCar_FromInvalidSpot()
        {
            Car car = new Car("BMW", "7777");
            string invalidSpot = "c#";

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.RemoveCar(invalidSpot, car);
            });
        }

        [Test]
        public void Test_RemoveCar_WithInvalidCar()
        {
            Car car = new Car("BMW", "7777");

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.RemoveCar("A2", new Car("someMake", "somePlate"));
            });
        }
    }
}