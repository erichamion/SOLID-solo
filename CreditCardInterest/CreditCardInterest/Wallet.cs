using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class Wallet : IWallet
    {
        private readonly List<ICreditCard> _cards;

        public Wallet(IList<ICreditCard> cards)
        {
            _cards = cards.ToList();
        }

        public double Balance
        {
            get
            {
                return _cards.Sum(x => x.Balance);
            }
        }

        public double Interest
        {
            get
            {
                return _cards.Sum(x => x.Interest);
            }
        }

        public double Principal
        {
            get
            {
                return _cards.Sum(x => x.Principal);
            }
        }

        public IList<ICreditCard> Cards
        {
            get
            {
                return _cards.AsReadOnly();
            }
        }

        public void PassTime(int periods)
        {
            _cards.ForEach(x => x.PassTime(periods));
        }
    }
}
