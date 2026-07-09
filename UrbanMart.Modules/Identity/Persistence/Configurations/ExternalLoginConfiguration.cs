using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanMart.Modules.Identity.Domain.Entities;

namespace UrbanMart.Modules.Identity.Persistence.Configurations
{
    public sealed class ExternalLoginConfiguration : IEntityTypeConfiguration<ExternalLogin>
    {
        public void Configure(EntityTypeBuilder<ExternalLogin> builder)
        {
            builder.ToTable("external_logins");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Provider)
           .HasMaxLength(50)
           .IsRequired();

            builder.Property(x => x.ProviderKey)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.Provider,
                x.ProviderKey
            })
            .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(x => x.ExternalLogins)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}