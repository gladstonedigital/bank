using System;

namespace Bank {
    public abstract class Account {
    }

    public class CheckingAccount : Account {
        public CheckingAccount() {
        }
    }

    public class SavingsAccount : Account {
        public static decimal interestRate = 0.10m;

        public SavingsAccount() {
        }
    }

    public class MoneyMarketAccount : SavingsAccount {
        public MoneyMarketAccount() {
        }
    }
}

