namespace WebApplication2.Models
{
    public class Product
    {
        public int ProductId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public long? CategoryId { get; set; }
        public long? ManufacturerId { get; set; }
        public Category? Category { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
