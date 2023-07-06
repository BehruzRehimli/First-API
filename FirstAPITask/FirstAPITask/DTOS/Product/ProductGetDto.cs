namespace FirstAPITask.DTOS.Product
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public BrandGetForProduct Brand { get; set; }

    }
    public class BrandGetForProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
