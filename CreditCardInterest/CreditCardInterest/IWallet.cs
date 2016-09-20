using System.Collections.Generic;

namespace CreditCardInterest
{
    public interface IWallet : IInterestBearingAccountContainer<ICreditCard>
    {
        
    }
}