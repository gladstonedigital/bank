using System;

namespace Bank {
    public abstract class Currency {
        public virtual decimal quantity { get; set; } = 0.0m;
        public virtual decimal exchangeRate { get; set; }
        public virtual string symbol { get; set; }
        public virtual string shortsymbol { get; set; }

        protected Currency() {}

        protected Currency(decimal quantity) {
            this.quantity = quantity;
            this.symbol = symbol;
        }
    }

    public class USD : Currency {
        public override decimal exchangeRate { get; set; } = 1.00m;
        public override string symbol { get; set; } = "USD";
        public override string shortsymbol { get; set; } = "$";

        public USD() {}

        public USD(decimal quantity) : base(quantity) {}
    }

    public class EUR : Currency {
        public override decimal exchangeRate { get; set; } = 1.20m;
        public override string symbol { get; set; } = "EUR";
        public override string shortsymbol { get; set; } = "€";

        public EUR() {}

        public EUR(decimal quantity) : base(quantity) {}
    }
}

