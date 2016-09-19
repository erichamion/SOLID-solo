using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class SimpleInterestCalculator
    {
        public PrincipalInterestBalance CalculateInterest(double startingPrincipal, double ratePerPeriod, int periods)
        {
            return new PrincipalInterestBalance {
                Interest = startingPrincipal * ratePerPeriod * periods,
                Principal = startingPrincipal
            };
        }
    }
}
