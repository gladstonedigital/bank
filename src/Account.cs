using System;

namespace Bank {
    public abstract class Account {
        public virtual Currency balance { get; set; } = new USD();
        public virtual int accountNumber { get; set; } = 0;

        protected Account(int accountNumber) {
            this.accountNumber = accountNumber;
        }

        protected Account(int accountNumber, Currency balance) {
            this.balance = balance;
            this.accountNumber = accountNumber;
        }

        public virtual bool deposit(Currency amount) {
            if (String.Equals(balance.symbol, amount.symbol)) {
                this.balance.quantity += amount.quantity;
                return true;
            } else {
                Console.WriteLine("Account currency and deposit currency do not match; deposit failed.");
                return false;
            }
        }

        public virtual bool withdraw(Currency amount) {
            if (!String.Equals(balance.symbol, amount.symbol)) {
                Console.WriteLine("Account currency and withdraw currency do not match; withdraw failed.");
                return false;
            }

            if (balance.quantity - amount.quantity < 0.0m) {
                Console.WriteLine("Insufficient funds.");
                return false;
            }

            balance.quantity -= amount.quantity;
            return true;
        }

        public virtual bool transfer(Account from, Currency amount) {
            if (!String.Equals(balance.symbol, from.balance.symbol) || !String.Equals(balance.symbol, amount.symbol)) {
                Console.WriteLine("Transfer currencies do not match");
                return false;
            }

            if (from.accountNumber == accountNumber) {
                Console.WriteLine("Can't transfer between same account");
                return false;
            }

            return from.withdraw(amount) && deposit(amount);
        }

        public virtual void print() {
            Console.WriteLine("\nAccount number:\t" + accountNumber +
                              "\nAccount currency:\t" + balance.symbol +
                              "\nAccount balance:\t" + balance.shortsymbol + balance.quantity);
        }
    }

    public class CheckingAccount : Account {
        public const decimal overdraftFee = 20.00m;
        public CheckingAccount(int accountNumber) : base(accountNumber) {}
        public CheckingAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}

        public override bool withdraw(Currency amount) {
            if (!String.Equals(balance.symbol, amount.symbol)) {
                Console.WriteLine("Account currency and withdraw currency do not match; withdraw failed.");
                return false;
            }

            if (balance.quantity - amount.quantity >= 0.0m) {
                balance.quantity -= amount.quantity;
                return true;
            } else if (balance.quantity - amount.quantity - 20.0m >= -200.0m) {
                balance.quantity -= 20.0m + amount.quantity;
                Console.WriteLine("Overdraft; assessed $20.00 fee.");
                return true;
            } else {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
        }
    }

    public class SavingsAccount : Account {
        public virtual decimal interestRate { get; set; } = 0.10m;

        public SavingsAccount(int accountNumber) : base(accountNumber) {}
        public SavingsAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}
   }

    public class MoneyMarketAccount : SavingsAccount {
        public override decimal interestRate { get; set; } = 0.20m;
        public const decimal withdrawFee = 1.50m;

        public MoneyMarketAccount(int accountNumber) : base(accountNumber) {}
        public MoneyMarketAccount(int accountNumber, Currency balance) : base(accountNumber, balance) {}

        public override bool withdraw(Currency amount) {
            if (!String.Equals(balance.symbol, amount.symbol)) {
                Console.WriteLine("Account currency and withdraw currency do not match; withdraw failed.");
                return false;
            }

            if (balance.quantity - withdrawFee - amount.quantity < 0.0m) {
                Console.WriteLine("Insufficient funds.");
                return false;
            }

            balance.quantity -= withdrawFee + amount.quantity;
            return true;
        }
    }
}

