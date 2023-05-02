
using System.Collections.Generic;
using Model.Interfaces;

namespace Model.Registrations
{
    public class Manufacturer : IManufacturer
    {
        public long ManufacturerId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
