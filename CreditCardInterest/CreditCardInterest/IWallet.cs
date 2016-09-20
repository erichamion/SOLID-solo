using System.Collections.Generic;

namespace CreditCardInterest
{
    public interface IWallet : IInterestBearingAccount
    {
        IList<ICreditCard> Cards { get; }
    }
}