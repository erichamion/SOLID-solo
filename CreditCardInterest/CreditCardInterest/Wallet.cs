using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class Wallet : AbstractInterestBearingAccountContainer<ICreditCard>, IWallet
    {
        private List<ICreditCard> _cards;

        public override IList<ICreditCard> Accounts { get { return _cards.AsReadOnly(); } }

        public Wallet(IList<ICreditCard> cards) : this(cards, new InterestBalanceCollector())
        { }

        public Wallet(IList<ICreditCard> cards, IInterestBalanceCollector interestBalanceCollector)
            : base(interestBalanceCollector)
        {
            _cards = cards.ToList();
        }

        public override void PassTime(int periods)
        {
            _cards.ForEach(x => x.PassTime(periods));
        }
    }
}
