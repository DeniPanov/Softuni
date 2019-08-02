using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] testingData = new int[] { 1, 2, 3 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(testingData);
        }

        [Test]
        public void TestIfCountIsEqualsToDataLenght()
        {
            int expectedCount = 3;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestIfAddMethodWorksCorrectly()
        {
            int expectedCount = 4;

            database.Add(1);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestIfAddMethodThrowsTheProperException()
        {
            for (int i = 4; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });
        }

        [Test]
        public void TestIfRemoveMethodWorksCorrectly()
        {
            int expectedCount = 2;

            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestIfRemoveMethodThrowsTheProperException()
        {
            for (int i = 0; i < 3; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void TestIfFetchMethodIsWorkingCorrectly()
        {
            int[] fetchedArray = database.Fetch();

            CollectionAssert.AreEqual(this.testingData, fetchedArray);
        }
    }
}