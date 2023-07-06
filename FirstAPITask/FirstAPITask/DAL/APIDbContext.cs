using FirstAPITask.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstAPITask.DAL
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> opt) : base(opt) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
