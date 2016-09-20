using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public class GroupTimePasser : IGroupTimePasser
    {
        public void PassTimeForAll<T>(List<T> accounts, int periods) where T : ITimeSensitiveAccount
        {
            accounts.ForEach(x => x.PassTime(periods));
        }
    }
}
