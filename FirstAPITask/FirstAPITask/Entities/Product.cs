using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPITask.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public double Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double CostPrice { get; set; }
        public Brand Brand { get; set; }
    }
}
