using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class Wallet : AbstractInterestBearingAccountContainer<ICreditCard>, IWallet
    {
        private readonly List<ICreditCard> _cards;
        private readonly IGroupTimePasser _timePasser;

        public override IList<ICreditCard> Accounts { get { return _cards.AsReadOnly(); } }

        public Wallet(IList<ICreditCard> cards) : this(cards, new GroupTimePasser())
        { }

        public Wallet(IList<ICreditCard> cards, IInterestBalanceCollector balanceCollector)
            : this(cards, new GroupTimePasser(), balanceCollector)
        { }

        public Wallet(IList<ICreditCard> cards, IGroupTimePasser timePasser) 
            : this(cards, timePasser, new InterestBalanceCollector())
        { }

        public Wallet(IList<ICreditCard> cards, IGroupTimePasser timePasser, IInterestBalanceCollector balanceCollector)
            : base(balanceCollector)
        {
            _cards = cards.ToList();
            _timePasser = timePasser;
        }

        public override void PassTime(int periods)
        {
            _timePasser.PassTimeForAll(_cards, periods);
        }
    }
}
