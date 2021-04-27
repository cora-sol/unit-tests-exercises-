using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public static class AssertUtils
    {
        public static void AreApproximatelyEqual(float expected, float actual)
        {
            bool approximatelyEquals = Mathf.Approximately(expected, actual);
            Assert.IsTrue(approximatelyEquals);
        }
    }
}