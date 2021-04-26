using Utils;
using NUnit.Framework;

public class TestBank
{
    [Test]
    public void TestCreateAccount()
    {
        var bank = new MyBank();
        Assert.IsFalse(bank.HasAccount("0001"));

        bank.CreateAccount("0001");
        Assert.IsTrue(bank.HasAccount("0001"));
    }

    [Test]
    public void TestBasicDeposit()
    {
        var bank = new MyBank();
        
        bank.CreateAccount("0001");
        bank.Deposit("0001", 100);

        Assert.AreEqual(bank.GetBalance("0001"), 100);
    }

    [Test]
    public void TestDoubleDeposit()
    {
        var bank = new MyBank();

        bank.CreateAccount("0001");

        bank.Deposit("0001", 100);
        bank.Deposit("0001", 50);

        Assert.AreEqual(bank.GetBalance("0001"), 150);
    }

    [Test]
    public void TestFloatDeposit()
    {
        var bank = new MyBank();

        bank.CreateAccount("0001");

        bank.Deposit("0001", 0.1f);
        bank.Deposit("0001", 0.2f);

        Assert.AreEqual(bank.GetBalance("0001"), 0.3f);
    }
}