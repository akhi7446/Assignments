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
        public void TestAdd() => Assert.AreEqual(6, nf.Add(1, 2, 3));
        [Test]
        public void TestAdd1() => Assert.AreEqual(20, nf.Add(5, 6, 9));

        [Test]
        public void TestSubtract() => Assert.AreEqual(-1, nf.Subtract(2, 3));


        [Test]
        public void TestMultiply() => Assert.AreEqual(90, nf.Multiply(10, 9));

        [Test]
        public void TestDivide() => Assert.AreEqual(2.5, nf.Divide(5, 2));

        [Test]
        public void TestFindMax() => Assert.AreEqual(12, nf.FindMax(2, 3, 4, 5, 10, 12));

        [Test]
        public void TestFindMin() => Assert.AreEqual(2, nf.FindMin(2, 3, 4, 5, 10, 12));

        [Test]
        public void TestIsEven() => Assert.IsTrue(nf.IsEven(10));
        [Test]
        public void TestIsEven1() => Assert.IsFalse(nf.IsEven(7));

        [Test]
        public void TestIsOdd() => Assert.IsTrue(nf.IsOdd(7));
        [Test]
        public void TestIsOdd1() => Assert.IsFalse(nf.IsOdd(10));

        [Test]
        public void TestIsPrime() => Assert.IsTrue(nf.IsPrime(7));
        [Test]
        public void TestIsPrime1() => Assert.IsFalse(nf.IsPrime(10));

        [Test]
        public void TestGetEvenNumbersInRange()
        {
            var result = nf.GetEvenNumbersInRange(1, 20);
            CollectionAssert.AreEqual(new[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }, result);
        }

        [Test]
        public void TestGetOddNumbersInRange()
        {
            var result = nf.GetOddNumbersInRange(1, 20);
            CollectionAssert.AreEqual(new[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 }, result);
        }

        [Test]
        public void TestGetPrimeNumbersInRange()
        {
            var result = nf.GetPrimeNumbersInRange(1, 20);
            CollectionAssert.AreEqual(new[] { 2, 3, 5, 7, 11, 13, 17, 19 }, result);
        }

        [Test]
        public void TestGetTable()
        {
            var result = nf.GetTable(2);
            Assert.AreEqual("2 x 5 = 10", result[4]);
        }
        [Test]
        public void TestGetTable1()
        {
            var result = nf.GetTable(2);
            Assert.AreEqual("2 x 10 = 20", result[9]);
        }

        [Test]
        public void TestGetTablesFrom1To10()
        {
            var result = nf.GetTablesFrom1To10(1, 1);
            Assert.AreEqual(10, result.Count);
        }

        [Test]
        public void TestGetTablesFrom1To10a()
        {
            var result = nf.GetTablesFrom1To10(1, 1);
            Assert.AreEqual("1 x 1 = 1", result[0]);
        }

        [Test]
        public void TestGetTablesFromRange()
        {
            var result = nf.GetTablesFromRange(2, 2, 1, 5);
            Assert.AreEqual("2 x 5 = 10", result[4]);
        }
        [Test]
        public void TestGetTablesFromRange1()
        {
            var result = nf.GetTablesFromRange(2, 2, 1, 5);
            Assert.AreEqual("2 x 1 = 2", result[0]);
        }

        [Test]
        public void TestReverseNumber() => Assert.AreEqual(897, nf.ReverseNumber(798));
    }
}
