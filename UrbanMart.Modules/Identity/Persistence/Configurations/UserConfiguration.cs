using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UrbanMart.Modules.Identity.Domain.Entities;

namespace UrbanMart.Modules.Identity.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table
            builder.ToTable("users");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.MobileNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.PasswordHash)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.IsEmailVerified)
                .IsRequired();

            builder.Property(x => x.IsMobileNumberVerified)
                .IsRequired();

            // Unique Indexes
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => x.MobileNumber)
                .IsUnique();
        }
    }
}