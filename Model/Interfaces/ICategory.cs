using Model.Registrations;

namespace Model.Interfaces
{
    public interface ICategory
    {
        long CategoryId { get; set; }
        string CategoryName { get; set; }
        ICollection<Product>? Products { get; set; }
    }
}