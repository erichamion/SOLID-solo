using System.Collections.Generic;

namespace CreditCardInterest
{
    public interface IInterestBearingAccountContainer<T> : IInterestBearingAccount where T : IInterestBearingAccount
    {
        IList<T> Accounts { get; }
    }
}