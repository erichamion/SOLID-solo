using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class InterestBalanceCollector : IInterestBalanceCollector
    {
        public double GetTotal<T>(IList<T> accounts, Func<T, double> balanceSelector) where T : IInterestBearingAccount
        {
            return accounts.Sum(balanceSelector);
        }
    }
}
