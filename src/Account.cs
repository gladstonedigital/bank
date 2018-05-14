using System;

namespace Bank {
    public abstract class Account {
        public virtual Currency balance { get; set; } = new USD();
        public virtual int accountNumber { get; set; } = 0;
        public virtual decimal interestRate { get; set; } = 0.0m;

        protected Account(int accountNumber) {
            this.accountNumber = accountNumber;
        }

        protected Account(int accountNumber, Currency balance) {
            this.balance = balance;
            this.accountNumber = accountNumber;
        }
    }

    public class CheckingAccount : Account {
        public CheckingAccount(int accountNumber) : base(accountNumber) {}
        public CheckingAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}
    }

    public class SavingsAccount : Account {
        public override decimal interestRate { get; set; } = 0.10m;

        public SavingsAccount(int accountNumber) : base(accountNumber) {}
        public SavingsAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}
    }

    public class MoneyMarketAccount : SavingsAccount {
        public override decimal interestRate { get; set; } = 0.20m;

        public MoneyMarketAccount(int accountNumber) : base(accountNumber) {}
        public MoneyMarketAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}
    }
}

