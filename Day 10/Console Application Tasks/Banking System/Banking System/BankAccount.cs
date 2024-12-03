using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class BankAccount
    {
        private double Money;

        public BankAccount(double money)
        {
            Money = money;
        }

        public void AddMoney(double amount) //Deposit amount
        {
            if (amount > 0)
            {
                Money = Money + amount;
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public bool Subtract(double amount)
        {
            if (amount > 0 && Money >= amount)
            {
                Money = Money - amount;
                return true;
            }
            return false;
        }

        public void getInfo()
        {
            Console.WriteLine($"Your account balance is ${Money}");
        }

    }
}
