using System;
using System.Collections.Generic;

namespace Utils
{
    public class MyBank
    {
        private readonly Dictionary<string, float> accountsBalance = new Dictionary<string, float>();

        public void CreateAccount(string account, float initialBalance = 0)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Invalid balance", nameof(initialBalance));
            if (string.IsNullOrEmpty(account) || account.Length != 4)
                throw new ArgumentException("Invalid account", nameof(account));
            if (accountsBalance.ContainsKey(account))
                throw new ArgumentException("Already existent account", nameof(account));
            accountsBalance.Add(account, initialBalance);
        }

        public bool HasAccount(string account)
        {
            return accountsBalance.ContainsKey(account);
        }

        public void RemoveAccount(string account)
        {
            bool wasRemoved = accountsBalance.Remove(account);
            if (!wasRemoved)
                throw new ArgumentException("Non existent account");
        }

        public float GetBalance(string account)
        {
            if (!accountsBalance.TryGetValue(account, out float balance))
                throw new ArgumentException("Non existent account", nameof(account));
            return balance;
        }

        public void Deposit(string account, float amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid deposit", nameof(amount));
            if (!accountsBalance.TryGetValue(account, out float balance))
                throw new ArgumentException("Non existent account", nameof(account));
            float newBalance = balance + amount;
            accountsBalance[account] = newBalance;
        }

        public void Withdraw(string account, float amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid withdraw", nameof(amount));
            if (!accountsBalance.TryGetValue(account, out float balance))
                throw new ArgumentException("Non existent account", nameof(account));
            float newBalance = balance - amount;
            if (newBalance < 0)
                throw new ArgumentException("Invalid withdraw", nameof(newBalance));
            accountsBalance[account] = newBalance;
        }
    }
}