using System;

namespace Bank {
    public static class Program {
        public static void Main(string[] args) {
            Console.WriteLine("bankbois");
            Account bob = new SavingsAccount(1415);
            Console.WriteLine(bob.accountNumber + "\n" + bob.balance.quantity + "\n" + bob.interestRate);
            Account tim = new MoneyMarketAccount(12351, new USD(1154.01m));
            Console.WriteLine(tim.accountNumber + "\n" + tim.balance.quantity + "\n" + tim.interestRate);
        }
    }
}

