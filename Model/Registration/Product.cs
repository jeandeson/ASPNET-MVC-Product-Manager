using Model.Interfaces;
using Model.Tables;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Registrations
{
    public class Product : IProduct
    {
        [DisplayName("Id")]
        public long ProductId { get; set; } = 0;
        [DisplayName("Nome")]
        [StringLength(100, MinimumLength = 10, ErrorMessage =
              "O Nome deve ter no mínimo 10 e no máximo 100 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Data do Cadastro")]
        [Required(ErrorMessage = "Informe a data do cadastro do produto")]
        public DateTime? CreatedAt { get; set; }
        [DisplayName("Categoria")]
        public long? CategoryId { get; set; }
        [DisplayName("Fabricante")]
        public long? ManufacturerId { get; set; }
        public Category? Category { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
