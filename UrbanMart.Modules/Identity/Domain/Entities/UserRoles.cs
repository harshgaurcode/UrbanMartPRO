using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanMart.BuildingBlocks.Domain;
using UrbanMart.Modules.Identity.Domain.Enums;

namespace UrbanMart.Modules.Identity.Domain.Entities
{
    public class UserRole : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }

        public bool IsActive { get; set; }

        public User User { get; set; } = null!;

        public UserRoleType Role { get; set; }
    }
}