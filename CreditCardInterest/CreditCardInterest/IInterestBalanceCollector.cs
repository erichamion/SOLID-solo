using System;
using System.Collections.Generic;

namespace CreditCardInterest
{
    public interface IInterestBalanceCollector
    {
        double GetTotal<T>(IList<T> accounts, Func<T, double> balanceSelector) where T : IInterestBearingAccount;
    }
}