using System.ComponentModel.DataAnnotations;

namespace FirstAPITask.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
