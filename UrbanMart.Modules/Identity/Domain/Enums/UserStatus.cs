using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanMart.Modules.Identity.Domain.Enums
{
    public enum UserStatus
    {
        PendingVerification = 1,
        Active = 2,
        Suspended = 3,
        Locked = 4
    }
}