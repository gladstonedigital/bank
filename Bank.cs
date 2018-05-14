using System;

namespace Bank {
    public static class Program {
        public static void Main(string[] args) {
            Console.WriteLine("bankbois");
            Currency usd = new USD();
            Currency eur = new EUR();
            Console.WriteLine(usd.exchangeRate);
            Console.WriteLine(eur.exchangeRate);
        }
    }
}

