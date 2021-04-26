
using System;
using System.Collections.Generic;

namespace Utils
{
    public class MyBank
    {
        private Dictionary<string,float> accounts = new Dictionary<string, float>();

        private bool IsValidAccount(string account)
        {
            if (string.IsNullOrEmpty(account))
                return false;

            return account.Length != 4;
        }

        public float GetBalance(string account)
        {
            if (!accounts.ContainsKey(account))
                throw new ArgumentException("Unknown account");

            return accounts[account];
        }

        public void CreateAccount(string account, float initialBalance = 0)
        {
            if (IsValidAccount(account))
                throw new ArgumentException("Invalid account value");

            if (accounts.ContainsKey(account))
                throw new ArgumentException("Account already exists");

            accounts.Add(account, initialBalance);
        }

        public void RemoveAccount(string account)
        {
            if (accounts.ContainsKey(account))
                throw new ArgumentException("Account doesn't exists");

            accounts.Remove(account);
        }

        public bool HasAccount(string account)
        {
            return accounts.ContainsKey(account);
        }

        public void WithDraw(string account, float amount)
        {
            if (!accounts.ContainsKey(account))
                throw new ArgumentException("Unknown account");

            float balance = accounts[account];

            if ((balance - amount) < 0)
                throw new ArgumentException("Insufficient balance");

            accounts[account] -= amount;
        }

        public void Deposit(string account, float amount)
        {
            if (!accounts.ContainsKey(account))
                throw new ArgumentException("Unknown account");

            float balance = accounts[account];            
            accounts[account] += amount;
        }
    }
}
