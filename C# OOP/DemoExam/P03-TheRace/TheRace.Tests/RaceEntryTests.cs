using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{    
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private Dictionary<string, UnitRider> riders;
        private UnitRider rider;
        private UnitMotorcycle motorcycle;

        [SetUp]
        public void Setup()
        {
             this.raceEntry = new RaceEntry();
            riders = new Dictionary<string, UnitRider>();

            motorcycle = new UnitMotorcycle("Model", 60, 60);
            rider = new UnitRider("Ivan", motorcycle);

            riders.Add("Monza", rider);
        }

        [Test]
        public void TestIfConstructorIsWorkingCorrectly()
        {
            Assert.IsNotNull(riders);
        }

        [Test]
        public void TestAllGeters()
        {
            string expectedModel = "Model";
            int expectedHp = 60;
            double expectesCubicCentimeters = 60;

            string expectedDriverName = "Ivan";

            Assert.AreEqual(expectedModel, motorcycle.Model);
            Assert.AreEqual(expectedHp, motorcycle.HorsePower);
            Assert.AreEqual(expectesCubicCentimeters, motorcycle.CubicCentimeters);
            Assert.AreEqual(expectedDriverName, rider.Name);
        }

        [Test]
        public void TestIfCountIsWorkingCorrectly()
        {
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, riders.Count);
        }

        [Test]
        public void TestIfAddDriverMethodIsWorkingCorrectly()
        {
            int expectedCount = 1;
            UnitMotorcycle motorcycle1 = new UnitMotorcycle("someModel", 70, 70);
            UnitRider pesho = new UnitRider("Pesho", motorcycle1);

            raceEntry.AddRider(pesho);

            Assert.AreEqual(expectedCount, raceEntry.Counter);
        }

        [Test]
        public void TestIfNullDriverCanBeAdded()
        {
            UnitRider someRider = null;

            Assert.Throws<InvalidOperationException>(() =>
           {
               raceEntry.AddRider(someRider);
           });
        }

        [Test]
        public void TestIfADriverWithTheSameNameCanBeAdded()
        {
            raceEntry.AddRider(rider);

            UnitMotorcycle motorcycle1 = new UnitMotorcycle("someModel", 70, 70);
            UnitRider ivan = new UnitRider("Ivan", motorcycle1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(ivan);
            });
        }

        [Test]
        public void TestIfCalculateAverageHpIsWorkingCorrectly()
        {
            UnitMotorcycle motorcycle1 = new UnitMotorcycle("someModel1", 60, 60);
            UnitRider gosho = new UnitRider("Gosho", motorcycle1);

            UnitMotorcycle motorcycle2 = new UnitMotorcycle("someModel2", 60, 60);
            UnitRider niki = new UnitRider("Niki", motorcycle2);

            raceEntry.AddRider(rider);
            raceEntry.AddRider(gosho);
            raceEntry.AddRider(niki);

            int expectedAverageHp = 60;
            var averageHp = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAverageHp, averageHp);
        }

        [Test]
        public void TestIfCalculateAverageHpCanWorkWithLessThan2Drivers()
        {
            UnitMotorcycle motorcycle1 = new UnitMotorcycle("someModel1", 60, 60);
            UnitRider gosho = new UnitRider("Gosho", motorcycle1);

            raceEntry.AddRider(gosho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }
    }
}