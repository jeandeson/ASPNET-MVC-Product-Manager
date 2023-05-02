using Microsoft.EntityFrameworkCore;
using Model.Registrations;
using Model.Tables;

namespace Persistence.Interfaces
{
    public interface IEFContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<Product> Products { get; set; }
    }
}