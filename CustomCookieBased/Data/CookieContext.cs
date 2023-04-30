using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomCookieBased.Data
{
    public class CookieContext : DbContext
    {
        public CookieContext(DbContextOptions<CookieContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }

    }
}
