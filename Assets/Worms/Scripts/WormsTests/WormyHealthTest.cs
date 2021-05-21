using System;
using Worms;
using NUnit.Framework;

namespace WormsTests
{
    public class WormyHealthTest
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void ExceptionCreatingWithZeroOrNegativeHealth(int maxHealth)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new WormyHealth(maxHealth); });
        }

        [TestCase(1)]
        [TestCase(100)]
        public void IsFullAfterCreation(int maxHealth)
        {
            WormyHealth wormyHealth = new WormyHealth(maxHealth);
            Assert.AreEqual(maxHealth, wormyHealth.Health);
        }

        [TestCase(2, -1)]
        [TestCase(100, -69)]
        public void IsDecreasedAfterNegativeChange(int maxHealth, int negativeChange)
        {
            WormyHealth wormyHealth = new WormyHealth(maxHealth);
            wormyHealth.ChangeHealth(negativeChange);
            Assert.AreEqual(maxHealth + negativeChange, wormyHealth.Health);
        }

        [TestCase(2, -5)]
        [TestCase(100, -420)]
        public void IsZeroAfterGreaterNegativeChange(int maxHealth, int negativeChange)
        {
            WormyHealth wormyHealth = new WormyHealth(maxHealth);
            wormyHealth.ChangeHealth(negativeChange);
            Assert.AreEqual(0, wormyHealth.Health);
        }

        [TestCase(2, 1)]
        [TestCase(100, 69)]
        public void RemainsFullAfterPositiveChange(int maxHealth, int positiveChange)
        {
            WormyHealth wormyHealth = new WormyHealth(maxHealth);
            wormyHealth.ChangeHealth(positiveChange);
            Assert.AreEqual(maxHealth, wormyHealth.Health);
        }

        [TestCase(5, -2, 1)]
        [TestCase(100, -80, 69)]
        public void IsIncreasedAfterNegativeAndLesserPositiveChange(int maxHealth, int negativeChange, int lesserPositiveChange)
        {
            WormyHealth wormyHealth = new WormyHealth(maxHealth);
            wormyHealth.ChangeHealth(negativeChange);
            wormyHealth.ChangeHealth(lesserPositiveChange);
            Assert.AreEqual(maxHealth + negativeChange + lesserPositiveChange, wormyHealth.Health);
        }

        [TestCase(5, -1, 2)]
        [TestCase(100, -69, 80)]
        public void IsFullAfterNegativeAndGreaterPositiveChange(int maxHealth, int negativeChange, int greaterPositiveChange)
        {
            WormyHealth wormyHealth = new WormyHealth(maxHealth);
            wormyHealth.ChangeHealth(negativeChange);
            wormyHealth.ChangeHealth(greaterPositiveChange);
            Assert.AreEqual(maxHealth, wormyHealth.Health);
        }
    }
}