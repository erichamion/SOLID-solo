using System.Collections.Generic;

namespace CreditCardInterest
{
    public interface IWallet : ITimeSensitiveAccount
    {
        IList<ICreditCard> Cards { get; }
    }
}