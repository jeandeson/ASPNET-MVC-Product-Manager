using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Registrations;
using Model.Tables;
using Persistence.Interfaces;

namespace Persistence.Contexts
{
    public class EFContext : IdentityDbContext<ApplicationUser, IdentityRole, string>, IEFContext
    {
        public EFContext(IConfiguration configuration) : base(GetOptions(configuration)) { }
        private static DbContextOptions<EFContext> GetOptions(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Persistence"));
            return optionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(r => new { r.UserId, r.RoleId });
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
