using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options){}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
