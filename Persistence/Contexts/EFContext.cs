using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Registrations;
using Model.Tables;

namespace Persistence.Contexts
{
    public class EFContext : DbContext
    {   
        public EFContext(IConfiguration configuration) : base(GetOptions(configuration)){}
        private static DbContextOptions<EFContext> GetOptions(IConfiguration configuration) {
            var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
            
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Persistence"));
            return optionsBuilder.Options;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
