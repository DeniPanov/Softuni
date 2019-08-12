namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            spaceship = new Spaceship("SomeName", 10);            
        }

       [Test]
       public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "SomeName";
            int expectedCapacity = 10;

            int expectedCount = 0;

            Assert.AreEqual(expectedName, spaceship.Name);
            Assert.AreEqual(expectedCapacity, spaceship.Capacity);
            Assert.AreEqual(expectedCount, spaceship.Count);
        }

        [Test]
        public void TestIfConstructorIsEmpty()
        {
            Assert.IsNotNull(spaceship);
        }

        [Test]
        public void TestIfNameCanBeNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship samoSS = new Spaceship(null, 8);
            });
        }

        [Test]
        public void TestIfNameCanBeEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship samoSS = new Spaceship("", 8);
            });
        }

        //[Test]
        //public void TestIfNameCanBeWhiteSpace()
        //{
        //    Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        Spaceship samoSS = new Spaceship("   ", 8);
        //    });
        //}

        [Test]
        public void TestICapacityCanBeZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Spaceship samoSS = new Spaceship("Name", -8);
            });
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            Astronaut astronaut = new Astronaut("SomeName", 50);
            int expectedCount = 1;

            spaceship.Add(astronaut);

            Assert.AreEqual(expectedCount, spaceship.Count);
        }

        [Test]
        public void TestIFAstrounautCountCanBeMoreThanTheCapacity()
        {
            Spaceship spaceship2 = new Spaceship("asdd", 1);
            Astronaut astronaut = new Astronaut("SomeName", 50);
            Astronaut astronaut2 = new Astronaut("otherName", 60);

            spaceship2.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship2.Add(astronaut2);
            });
        }

        [Test]
        public void TestIFTheSameAstrounautCanBeAddedAgain()
        {
            Spaceship spaceship2 = new Spaceship("asdd", 10);
            Astronaut astronaut = new Astronaut("SomeName", 50);

            spaceship2.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship2.Add(astronaut);
            });
        }

        [Test]
        public void TestIfRemoveWorksCorrectly()
        {
            Astronaut astronaut = new Astronaut("SomeName", 50);
            int expectedCount = 0;

            spaceship.Add(astronaut);
            spaceship.Remove("SomeName");

            Assert.AreEqual(expectedCount, spaceship.Count);
        }
    }
}