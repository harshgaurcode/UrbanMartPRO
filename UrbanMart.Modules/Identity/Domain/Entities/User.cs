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
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public bool EmailVerified { get; set; }

        public bool MobileVerified { get; set; }

        public UserStatus Status { get; set; }

        public bool IsEmailVerified { get; set; }

        public bool IsMobileNumberVerified { get; set; }
    }

    public class UserRole
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public bool IsActive { get; set; }

        public User User { get; set; } = null!;

        public Role Role { get; set; } = null!;
    }
}