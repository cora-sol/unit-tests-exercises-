using System;
using Utils;
using NUnit.Framework;

namespace Tests
{
    public class MyBankTest
    {
        private const string Account1 = "0001";
        private const string Account2 = "0002";

        private MyBank bank;

        [SetUp]
        public void Setup()
        {
            bank = new MyBank();
        }

        #region HasAccount

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void DoesntHaveAccountBeforeCreation(string account)
        {
            bool hasAccount = bank.HasAccount(account);
            Assert.IsFalse(hasAccount);
        }

        #endregion

        #region CreateAccount

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void HasAccountAfterCreation(string account)
        {
            bank.CreateAccount(account);
            bool hasAccount = bank.HasAccount(account);
            Assert.IsTrue(hasAccount);
        }

        [Test]
        public void HasAccountsAfterCreation()
        {
            bank.CreateAccount(Account1);
            bank.CreateAccount(Account2);
            bool hasAccount1 = bank.HasAccount(Account1);
            bool hasAccount2 = bank.HasAccount(Account2);
            Assert.IsTrue(hasAccount1);
            Assert.IsTrue(hasAccount2);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("001")]
        [TestCase("00001")]
        public void ExceptionCreatingInvalidAccount(string account)
        {
            Assert.Throws<ArgumentException>(() => bank.CreateAccount(account));
        }

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void ExceptionCreatingExistentAccount(string account)
        {
            bank.CreateAccount(account);
            Assert.Throws<ArgumentException>(() => bank.CreateAccount(account));
        }

        [Test]
        [TestCase(Account1, -1f)]
        [TestCase(Account1, -420.69f)]
        public void ExceptionCreatingAccountWithNegativeBalance(string account, float initialBalance)
        {
            Assert.Throws<ArgumentException>(() => bank.CreateAccount(account, initialBalance));
        }

        #endregion

        #region GetBalance

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void ExceptionGettingBalanceOfNonExistentAccount(string account)
        {
            Assert.Throws<ArgumentException>(() => bank.GetBalance(account));
        }

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void HasZeroInitialBalanceAfterParameterlessCreation(string account)
        {
            bank.CreateAccount(account);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(0, balance);
        }

        [Test]
        [TestCase(Account1, 0f)]
        [TestCase(Account1, 1f)]
        [TestCase(Account1, 420.69f)]
        [TestCase(Account2, 0f)]
        [TestCase(Account2, 0.1f)]
        [TestCase(Account2, 420.69f)]
        public void HasInitialBalanceAfterCreation(string account, float initialBalance)
        {
            bank.CreateAccount(account, initialBalance);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(initialBalance, balance);
        }

        #endregion

        #region RemoveAccount

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void ExceptionRemovingNonExistentAccount(string account)
        {
            Assert.Throws<ArgumentException>(() => bank.RemoveAccount(account));
        }

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void DoesntHaveAccountAfterRemoval(string account)
        {
            bank.CreateAccount(account);
            bank.RemoveAccount(account);
            bool hasAccount = bank.HasAccount(account);
            Assert.IsFalse(hasAccount);
        }

        #endregion

        #region Deposit

        [Test]
        [TestCase(Account1, 0f)]
        [TestCase(Account1, -1f)]
        [TestCase(Account1, -420.69f)]
        public void ExceptionDoingZeroOrNegativeDeposit(string account, float depositAmount)
        {
            bank.CreateAccount(account);
            Assert.Throws<ArgumentException>(() => bank.Deposit(account, depositAmount));
        }

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void ExceptionDoingDepositToNonExistentAccount(string account)
        {
            Assert.Throws<ArgumentException>(() => bank.Deposit(account, 1f));
        }

        [Test]
        [TestCase(Account1, 1f)]
        [TestCase(Account1, 420.69f)]
        [TestCase(Account2, 0.1f)]
        [TestCase(Account2, 420.69f)]
        public void HasNewBalanceAfterDeposit(string account, float depositAmount)
        {
            bank.CreateAccount(account);
            bank.Deposit(account, depositAmount);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(depositAmount, balance);
        }

        [Test]
        [TestCase(Account1, 1f, 0.1f)]
        [TestCase(Account1, 420.69f, 8888.88f)]
        public void HasNewBalanceAfterDeposits(string account, float depositAmount1, float depositAmount2)
        {
            bank.CreateAccount(account);
            bank.Deposit(account, depositAmount1);
            bank.Deposit(account, depositAmount2);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(depositAmount1 + depositAmount2, balance);
        }

        #endregion

        #region Withdraw

        [Test]
        [TestCase(Account1, 0f)]
        [TestCase(Account1, -1f)]
        [TestCase(Account1, -420.69f)]
        public void ExceptionDoingZeroOrNegativeWithdraw(string account, float withdrawAmount)
        {
            bank.CreateAccount(account);
            Assert.Throws<ArgumentException>(() => bank.Withdraw(account, withdrawAmount));
        }

        [Test]
        [TestCase(Account1)]
        [TestCase(Account2)]
        public void ExceptionDoingWithdrawToNonExistentAccount(string account)
        {
            Assert.Throws<ArgumentException>(() => bank.Withdraw(account, 1f));
        }

        [Test]
        [TestCase(Account1, 0f, 1f)]
        [TestCase(Account1, 420.69f, 420.691f)]
        public void ExceptionDoingWithdrawWithLesserBalance(string account, float initialBalance, float withdrawAmount)
        {
            bank.CreateAccount(account, initialBalance);
            Assert.Throws<ArgumentException>(() => bank.Withdraw(account, withdrawAmount));
        }

        [Test]
        [TestCase(Account1, 1000f, 1f)]
        [TestCase(Account1, 1000f , 420.69f)]
        [TestCase(Account2, 1f , 1f)]
        [TestCase(Account2, 420.69f, 0.1f)]
        public void HasNewBalanceAfterWithdraw(string account, float initialBalance, float withdrawAmount)
        {
            bank.CreateAccount(account, initialBalance);
            bank.Withdraw(account, withdrawAmount);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(initialBalance - withdrawAmount, balance);
        }

        [Test]
        [TestCase(Account1, 1000f, 1f, 0.1f)]
        [TestCase(Account1, 1000f, 420.69f, 420.69f)]
        public void HasNewBalanceAfterWithdraws(string account, float initialBalance, float withdrawAmount1, float withdrawAmount2)
        {
            bank.CreateAccount(account, initialBalance);
            bank.Withdraw(account, withdrawAmount1);
            bank.Withdraw(account, withdrawAmount2);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(initialBalance - withdrawAmount1 - withdrawAmount2, balance);
        }

        [Test]
        [TestCase(Account1, 420.69f, 1f)]
        [TestCase(Account1, 420.69f, 420.69f)]
        public void HasNewBalanceAfterDepositAndWithdraw(string account, float depositAmount, float withdrawAmount)
        {
            const float initialBalance = 1000f;
            bank.CreateAccount(account, initialBalance);
            bank.Deposit(account, depositAmount);
            bank.Withdraw(account, withdrawAmount);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(initialBalance + depositAmount - withdrawAmount, balance);
        }

        [Test]
        [TestCase(Account1, 1f, 420.69f)]
        [TestCase(Account1, 420.69f, 420.69f)]
        public void HasNewBalanceAfterWithdrawAndDeposit(string account, float withdrawAmount, float depositAmount)
        {
            const float initialBalance = 1000f;
            bank.CreateAccount(account, initialBalance);
            bank.Withdraw(account, withdrawAmount);
            bank.Deposit(account, depositAmount);
            float balance = bank.GetBalance(account);
            AssertUtils.AreApproximatelyEqual(initialBalance - withdrawAmount + depositAmount, balance);
        }

        #endregion
    }
}