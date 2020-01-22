using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public enum Reproduce
    {
        Always,
        Sometimes,
        Random,
        HaveNotTried,
        UnableToReproduce,
        NotAvailible,
    }
}
