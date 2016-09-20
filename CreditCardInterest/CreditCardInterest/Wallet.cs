using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class Wallet
    {
        private readonly List<ITimeSensitiveAccount> _cards;

        public Wallet(List<ITimeSensitiveAccount> cards)
        {
            _cards = cards;
        }

        public double Balance
        {
            get
            {
                return _cards.Sum(x => x.Balance);
            }
        }

        public void PassTime(int periods)
        {
            _cards.ForEach(x => x.PassTime(periods));
        }
    }
}
