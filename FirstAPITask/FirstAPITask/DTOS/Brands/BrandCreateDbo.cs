using System.ComponentModel.DataAnnotations;

namespace FirstAPITask.DTOS.Brands
{
    public class BrandCreateDbo
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
