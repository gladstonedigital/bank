using System;

namespace Bank {
    public abstract class Currency {
        private decimal _exchangeRate;
        public decimal exchangeRate {
            get { return _exchangeRate; }
            set { _exchangeRate = value; }
        }
    }

    public class USD : Currency {
        public USD() {
            exchangeRate = 1.00m;
        }
    }

    public class EUR : Currency {
        public EUR() {
            exchangeRate = 1.20m;
        }
    }
}

