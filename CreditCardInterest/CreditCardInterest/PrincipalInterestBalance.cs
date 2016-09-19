using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class PrincipalInterestBalance
    {
        public double Total
        {
            get
            {
                return Interest + Principal;
            }
        }

        public double Interest { get; set; }
        public double Principal { get; set; }

        public static PrincipalInterestBalance operator +(PrincipalInterestBalance a, PrincipalInterestBalance b)
        {
            return a.Add(b);
        }

        public PrincipalInterestBalance Add(PrincipalInterestBalance other)
        {
            return new PrincipalInterestBalance
            {
                Interest = this.Interest + other.Interest,
                Principal = this.Principal + other.Principal
            };
        }
    }
}
