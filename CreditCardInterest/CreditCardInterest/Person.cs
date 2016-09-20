using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class Person : AbstractInterestBearingAccountContainer<IWallet>, IPerson
    {
        private readonly List<IWallet> _wallets;
        private readonly IGroupTimePasser _timePasser;

        public override IList<IWallet> Accounts { get { return _wallets.AsReadOnly(); } }

        public Person(IList<IWallet> wallets) : this(wallets, new GroupTimePasser())
        { }

        public Person(IList<IWallet> wallets, IGroupTimePasser timePasser)
            : this(wallets, timePasser, new InterestBalanceCollector())
        { }

        public Person(IList<IWallet> wallets, IInterestBalanceCollector balanceCollector) 
            : this(wallets, new GroupTimePasser(), balanceCollector)
        { }
            

        public Person(IList<IWallet> wallets, IGroupTimePasser timePasser, IInterestBalanceCollector balanceCollector)
            : base(balanceCollector)
        {
            _wallets = wallets.ToList();
            _timePasser = timePasser;
        }

        public override void PassTime(int periods)
        {
            _timePasser.PassTimeForAll(_wallets, periods);
        }
    }
}
