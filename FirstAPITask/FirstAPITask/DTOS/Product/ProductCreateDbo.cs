using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FirstAPITask.DTOS.Product
{
    public class ProductCreateDbo
    {
        public int BrandId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, int.MaxValue)]
        public double Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, int.MaxValue)]
        public double CostPrice { get; set; }
    }
}
