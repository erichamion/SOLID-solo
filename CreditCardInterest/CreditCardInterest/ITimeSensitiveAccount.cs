﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterest
{
    public interface ITimeSensitiveAccount
    {
        void PassTime(int periods);
    }
}
