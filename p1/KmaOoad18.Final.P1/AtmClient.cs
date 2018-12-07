using System.Collections.Generic;

namespace KmaOoad18.Final.P1
{
    public class AtmClient
    {
        private Dictionary<int, int> banknotesAmountPairs = new Dictionary<int, int>();
        
        // What banknotes ATM has at the moment, e.g. [50, 200, 500] etc
        public List<int> AvailableBanknotes()
        {
            List<int> ava = new List<int>();
            foreach (int key in banknotesAmountPairs.Keys)
                if (banknotesAmountPairs[key] > 0)
                    ava.Add(key);
            ava.Sort();

            return ava;
            //return new List<int>();
        }

        // How much money ATM has
        public long AvailableAmount()
        {
            long sum = 0;
            foreach (int key in banknotesAmountPairs.Keys)
                sum += banknotesAmountPairs[key] * key;

            return sum;
        }

        // Input is list of pairs - banknote and its quantity, e.g. (100, 1000), (200, 500) etc,
        // that means we load ATM with 1000 of 100 banknotes and 500 of 200 banknotes
        public AtmClient Refill(params (int banknote, int qty)[] cash)
        {
            //banknotesAmountPairs = new Dictionary<int, int>();
            //List<int> banks = AvailableBanknotes();
            foreach ((int b, int q) in cash)
                banknotesAmountPairs[b] = q;
            
            return this;
        }

        // Take provided amount of money from the ATM
        // Check that ATM has enough banknotes to give that amount
        public AtmClient Withdraw(long amount)
        {

            // Update ATM 
            if (AvailableAmount() >= amount)
            {
                List<int> ava = AvailableBanknotes();
                ava.Reverse();
                foreach (int banknoteType in ava)
                {
                    long toWith = System.Math.Min(
                        banknotesAmountPairs[banknoteType], amount / banknoteType
                        );
                    banknotesAmountPairs[banknoteType] -= (int)toWith;
                    amount -= banknoteType * toWith;
                    if (amount == 0) break;
                }
            }
            //else throw new System.Exception("ATM has not enough money to withdrow");
            
            return this;
        }
    }
}
