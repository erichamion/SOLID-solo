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
    }
}
