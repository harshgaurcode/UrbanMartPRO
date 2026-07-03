using Microsoft.EntityFrameworkCore;
using System;
using UrbanMart.Modules.Identity.Domain.Entities;

namespace UrbanMart.Modules.Identity.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("user_roles");

            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne(ur => ur.User);

            builder.HasOne(ur => ur.Role);
        }
    }
}