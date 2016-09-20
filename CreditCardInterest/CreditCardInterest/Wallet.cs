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
        private readonly IInterestBalanceCollector _interestBalanceCollector;

        public Wallet(IList<ICreditCard> cards) : this(cards, new InterestBalanceCollector())
        { }

        public Wallet(IList<ICreditCard> cards, IInterestBalanceCollector interestBalanceCollector)
        {
            _cards = cards.ToList();
            this._interestBalanceCollector = interestBalanceCollector;
        }

        public double Balance
        {
            get
            {
                return _interestBalanceCollector.GetTotal(_cards, x => x.Balance);
            }
        }

        public double Interest
        {
            get
            {
                return _interestBalanceCollector.GetTotal(_cards, x => x.Interest);
            }
        }

        public double Principal
        {
            get
            {
                return _interestBalanceCollector.GetTotal(_cards, x => x.Principal);
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
