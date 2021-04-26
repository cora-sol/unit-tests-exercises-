using Utils;
using NUnit.Framework;

public class TestNumberUtils
{    
    [Test]
    public void TestIsPositive()
    {
        var n = new NumberUtility();
        Assert.IsTrue(n.IsPositive(6));
    }

    [Test]
    public void TestIsNegative()
    {
        var n = new NumberUtility();
        Assert.IsFalse(n.IsPositive(-3));
    }

    [Test]
    public void TestIsZero()
    {
        var n = new NumberUtility();
        Assert.IsTrue(n.IsPositive(0));
    }
}
