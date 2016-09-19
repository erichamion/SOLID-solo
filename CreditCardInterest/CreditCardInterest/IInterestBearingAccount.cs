using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public interface IInterestBearingAccount : ITimeSensitiveAccount
    {
        
        double Interest { get; }
        double Principal { get; }

        
    }
}
