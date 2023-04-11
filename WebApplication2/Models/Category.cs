using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Category
    {
        public long CategoryId { get; set; } = 0;
        public string CategoryName { get; set; } = string.Empty;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
