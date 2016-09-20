using System.Collections.Generic;

namespace CreditCardInterest
{
    public interface IGroupTimePasser
    {
        void PassTimeForAll<T>(List<T> accounts, int periods) where T : ITimeSensitiveAccount;
    }
}