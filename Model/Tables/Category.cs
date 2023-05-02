
using Model.Interfaces;
using Model.Registrations;
using System.Collections.Generic;

namespace Model.Tables
{
    public class Category : ICategory
    {
        public long CategoryId { get; set; } = 0;
        public string CategoryName { get; set; } = string.Empty;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
