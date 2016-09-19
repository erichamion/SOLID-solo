using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class CreditCard : ICreditCard
    {
        private IDiscreteInterestCalculator _interestCalculator;
        private readonly double _rate;
        private PrincipalInterestBalance _principalInterestBalance;

        public string Name { get; }
        public double Balance { get { return _principalInterestBalance.Total; } }

        public double Principal { get { return _principalInterestBalance.Principal; } }
        public double Interest { get { return _principalInterestBalance.Interest; } }
        
        public CreditCard(string name, double startingBalance, double ratePerPeriod, IDiscreteInterestCalculator interestCalculator)
        {
            Name = name;
            _principalInterestBalance = new PrincipalInterestBalance { Principal = startingBalance, Interest = 0 };
            _rate = ratePerPeriod;
            _interestCalculator = interestCalculator;
        }

        
        public void PassTime(int periods)
        {
            _principalInterestBalance += _interestCalculator.CalculateInterest(Principal, _rate, periods);
        }
    }
}
