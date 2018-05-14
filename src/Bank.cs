using System;

namespace Bank {
    public static class Program {
        public static void Main(string[] args) {
            Console.WriteLine("bankbois");
            Account bob = new CheckingAccount(1415);
            bob.print();
            bob.deposit(new USD(200.0m));
            bob.print();
            bob.deposit(new EUR(20.0m));
            bob.print();
            bob.withdraw(new USD(10.0m));
            bob.print();
            bob.withdraw(new USD(200.0m));
            bob.print();
            bob.withdraw(new USD(200.0m));
            bob.print();

            Account tim = new MoneyMarketAccount(112233);
            tim.balance = new EUR();
            tim.deposit(new EUR(15000.0m));
            tim.print();
            tim.transfer(bob, new USD(12));
            Account tom = new SavingsAccount(223344);
            tom.balance = new EUR();
            tom.deposit(new EUR(10.0m));
            tom.print();
            tom.transfer(tim, new EUR(4.0m));
            tim.print();
            tom.print();
        }
    }
}

