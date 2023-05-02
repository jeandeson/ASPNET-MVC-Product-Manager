using Model.Registrations;
using Model.Tables;

namespace Model.Interfaces
{
    public interface IProduct
    {
        Category? Category { get; set; }
        long? CategoryId { get; set; }
        DateTime? CreatedAt { get; set; }
        Manufacturer? Manufacturer { get; set; }
        long? ManufacturerId { get; set; }
        string Name { get; set; }
        long ProductId { get; set; }
    }
}