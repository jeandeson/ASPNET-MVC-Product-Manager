using Model.Registrations;

namespace Service.Interfaces
{
    public interface IManufacturerService
    {
        void DeleteManufacturer(long? id);
        Manufacturer GetManufacturerById(long? id);
        IOrderedQueryable<Manufacturer> GetManufacturersOrderedByName();
        void InsertManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);
    }
}