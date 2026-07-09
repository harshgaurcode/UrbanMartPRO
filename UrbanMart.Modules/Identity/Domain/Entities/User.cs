using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanMart.BuildingBlocks.Domain;
using UrbanMart.Modules.Identity.Domain.Enums;

namespace UrbanMart.Modules.Identity.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? MobileNumber { get; set; }

        public string? PasswordHash { get; set; }

        public UserStatus Status { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; } = [];
        public ICollection<ExternalLogin> ExternalLogins { get; private set; } = [];
    }
}