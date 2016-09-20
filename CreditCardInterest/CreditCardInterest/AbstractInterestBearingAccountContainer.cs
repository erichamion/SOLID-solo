using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    

    public abstract class AbstractInterestBearingAccountContainer<T> : IInterestBearingAccount, IInterestBearingAccountContainer<T> where T : IInterestBearingAccount
    {
        private readonly IInterestBalanceCollector _balanceCollector;
        public abstract IList<T> Accounts { get; }

        protected AbstractInterestBearingAccountContainer(IInterestBalanceCollector balanceCollector)
        {
            _balanceCollector = balanceCollector;
        }

        public double Balance
        {
            get
            {
                return _balanceCollector.GetTotal(Accounts, x => x.Balance);
            }
        }

        public double Interest
        {
            get
            {
                return _balanceCollector.GetTotal(Accounts, x => x.Interest);
            }
        }

        public double Principal
        {
            get
            {
                return _balanceCollector.GetTotal(Accounts, x => x.Principal);
            }
        }

        public abstract void PassTime(int periods);
    }
}
