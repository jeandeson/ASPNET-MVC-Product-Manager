using Model.Registrations;

namespace Persistence.Interfaces
{
    public interface IManufacturerDAL
    {
        bool DeleteManufacturer(Manufacturer manufacturer);
        Manufacturer? GetManufacturerById(long id);
        IOrderedQueryable<Manufacturer> GetManufacturersOrderedByName();
        bool InsertManufacturer(Manufacturer manufacturer);
        bool UpdateManufacturer(Manufacturer manufacturer);
    }
}