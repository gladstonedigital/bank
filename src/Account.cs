using System;

namespace Bank {
    public abstract class Account {
        public virtual Currency balance { get; set; } = new USD();
        public virtual int accountNumber { get; set; } = 0;
        public virtual decimal interestRate { get; set; } = 0.0m;

        protected Account() {
        }

        protected Account(int accountNumber, Currency balance) : this() {
            this.balance = balance;
            this.accountNumber = accountNumber;
        }
    }

    public class CheckingAccount : Account {
        public CheckingAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}
    }

    public class SavingsAccount : Account {
        public override decimal interestRate { get; set; } = 0.10m;

        public SavingsAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}
    }

    public class MoneyMarketAccount : SavingsAccount {
        public override decimal interestRate { get; set; } = 0.20m;

        public MoneyMarketAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}
    }
}

