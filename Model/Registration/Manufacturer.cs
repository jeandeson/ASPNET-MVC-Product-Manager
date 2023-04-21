
using System.Collections.Generic;

namespace Model.Registrations
{
    public class Manufacturer
    {
        public long ManufacturerId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
