using CustomCookieBased.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCookieBased.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(new AppUser
            {
                Id = 1,
                Username = "Burak",
                Password = "1",
            });

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Username)
                   .IsRequired()
                   .HasMaxLength(250);
        }
    }

    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole
            {
                Id = 1,
                Definition = "Admin"
            });

            builder.Property(x => x.Definition)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }

    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole
            {
                RoleId = 1,
                UserId = 1,
            });

            builder.HasKey(X => new { X.UserId, X.RoleId });

            builder.HasOne(x => x.AppRole)
                   .WithMany(x => x.UserRoles)
                   .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.AppUser)
                   .WithMany(x => x.UserRoles)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
