using FirstAPITask.Entities;
using System.ComponentModel.DataAnnotations;

namespace FirstAPITask.DTOS.Brands
{
    public class BrandGetDbo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Entities.Product> Products { get; set; }
    }
}
