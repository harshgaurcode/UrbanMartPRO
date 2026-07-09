using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanMart.BuildingBlocks.Model.Enum
{
    public enum ResponseStatus
    {
        Success = 1,
        Failed = 2,
        NotFound = 3,
        Unauthorized = 4,
        BadRequest = 5
    }
}