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

        public UserStatus Status { get; set; }

        public bool IsEmailVerified { get; set; }

        public bool IsMobileNumberVerified { get; set; }

        public ICollection<UserRole> UserRoles { get; private set; } = [];
    }

    public class UserRole
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public bool IsActive { get; set; }

        public User User { get; set; } = null!;

        public Role Role { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}