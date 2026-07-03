using Microsoft.EntityFrameworkCore;
using UrbanMart.Modules.Identity.Domain.Entities;

namespace UrbanMart.Modules.Identity.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255);
        }
    }
}