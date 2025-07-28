using NUnit.Framework;
using Assignment11;

namespace Tests
{
    [TestFixture]
    public class NumericTests
    {
        private NumericFunctions nf;

        [SetUp]
        public void Setup()
        {
            nf = new NumericFunctions();
        }

        [Test]
        public void TestAdd() => Assert.AreEqual(10, nf.Add(1, 2, 3, 4));

        [Test]
        public void TestSubtract() => Assert.AreEqual(5, nf.Subtract(10, 5));

        [Test]
        public void TestMultiply() => Assert.AreEqual(15, nf.Multiply(3, 5));

        [Test]
        public void TestDivide() => Assert.AreEqual(2.5f, nf.Divide(5f, 2f));

        [Test]
        public void TestFindMax() => Assert.AreEqual(9, nf.FindMax(2, 9, 4));

        [Test]
        public void TestFindMin() => Assert.AreEqual(1, nf.FindMin(5, 1, 7));

        [Test]
        public void TestIsEven() => Assert.IsTrue(nf.IsEven(4));

        [Test]
        public void TestIsOdd() => Assert.IsTrue(nf.IsOdd(3));

        [Test]
        public void TestIsPrime() => Assert.IsTrue(nf.IsPrime(7));

        [Test]
        public void TestGetEvenNumbersInRange()
        {
            var result = nf.GetEvenNumbersInRange(1, 5);
            CollectionAssert.AreEqual(new[] { 2, 4 }, result);
        }

        [Test]
        public void TestGetOddNumbersInRange()
        {
            var result = nf.GetOddNumbersInRange(1, 5);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, result);
        }

        [Test]
        public void TestGetPrimeNumbersInRange()
        {
            var result = nf.GetPrimeNumbersInRange(1, 10);
            CollectionAssert.AreEqual(new[] { 2, 3, 5, 7 }, result);
        }

        [Test]
        public void TestGetTable()
        {
            var result = nf.GetTable(2);
            Assert.AreEqual("2 x 5 = 10", result[4]);
        }

        [Test]
        public void TestGetTablesFrom1To10()
        {
            var result = nf.GetTablesFrom1To10(1, 1);
            Assert.AreEqual(10, result.Count);
        }

        [Test]
        public void TestGetTablesFromRange()
        {
            var result = nf.GetTablesFromRange(2, 2, 1, 5);
            Assert.AreEqual("2 x 5 = 10", result[4]);
        }

        [Test]
        public void TestReverseNumber() => Assert.AreEqual(321, nf.ReverseNumber(123));
    }
}
