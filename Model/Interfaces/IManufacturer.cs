using Model.Registrations;

namespace Model.Interfaces
{
    public interface IManufacturer
    {
        long ManufacturerId { get; set; }
        string Name { get; set; }
        ICollection<Product>? Products { get; set; }
    }
}