using System;

namespace Bank {
    public static class Program {
        public static void Main(string[] args) {
            Console.WriteLine("bankbois");
            Account bob = new CheckingAccount(1415);
            Console.WriteLine("\nAccount #:\t" + bob.accountNumber + "\n" +
                              "Balance:\t" + bob.balance.quantity + "\n" + 
                              "Interest rate:\t" + bob.interestRate);
            bob.deposit(new USD(200.0m));
            Console.WriteLine("\nAccount #:\t" + bob.accountNumber + "\n" +
                              "Balance:\t" + bob.balance.quantity + "\n" + 
                              "Interest rate:\t" + bob.interestRate);
            bob.deposit(new EUR(20.0m));
            Console.WriteLine("\nAccount #:\t" + bob.accountNumber + "\n" +
                              "Balance:\t" + bob.balance.quantity + "\n" + 
                              "Interest rate:\t" + bob.interestRate);
            bob.withdraw(new USD(10.0m));
            Console.WriteLine("\nAccount #:\t" + bob.accountNumber + "\n" +
                              "Balance:\t" + bob.balance.quantity + "\n" + 
                              "Interest rate:\t" + bob.interestRate);
            bob.withdraw(new USD(200.0m));
            Console.WriteLine("\nAccount #:\t" + bob.accountNumber + "\n" +
                              "Balance:\t" + bob.balance.quantity + "\n" + 
                              "Interest rate:\t" + bob.interestRate);
            bob.withdraw(new USD(200.0m));
            Console.WriteLine("\nAccount #:\t" + bob.accountNumber + "\n" +
                              "Balance:\t" + bob.balance.quantity + "\n" + 
                              "Interest rate:\t" + bob.interestRate);
        }
    }
}

