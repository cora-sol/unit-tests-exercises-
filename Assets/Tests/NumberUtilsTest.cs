using Utils;
using NUnit.Framework;

namespace Tests
{
    public class NumberUtilsTest
    {
        [TestCase(6)]
        [TestCase(1)]
        [TestCase(1582313)]
        public void IsNumberPositive(int number)
        {
            bool isPositive = NumberUtils.IsPositive(number);
            Assert.IsTrue(isPositive);
        }

        [TestCase(-3)]
        [TestCase(-1)]
        [TestCase(-4378)]
        public void IsNumberNegative(int number)
        {
            bool isPositive = NumberUtils.IsPositive(number);
            Assert.IsFalse(isPositive);
        }

        [Test]
        public void IsZeroPositive()
        {
            bool isPositive = NumberUtils.IsPositive(0);
            Assert.IsTrue(isPositive);
        }
    }
}