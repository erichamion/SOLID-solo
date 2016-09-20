using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class Person : AbstractInterestBearingAccountContainer<IWallet>, IPerson
    {
        private List<IWallet> _wallets;

        public override IList<IWallet> Accounts { get { return _wallets.AsReadOnly(); } }

        public Person(IList<IWallet> wallets) : this(wallets, new InterestBalanceCollector())
        { }

        public Person(IList<IWallet> wallets, IInterestBalanceCollector interestBalanceCollector)
            : base(interestBalanceCollector)
        {
            _wallets = wallets.ToList();
        }

        public override void PassTime(int periods)
        {
            _wallets.ForEach(x => x.PassTime(periods));
        }
    }
}
