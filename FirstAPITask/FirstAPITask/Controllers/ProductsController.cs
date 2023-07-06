using FirstAPITask.DAL;
using FirstAPITask.DTOS.Product;
using FirstAPITask.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ProductsController(APIDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("page/{page}")]
        public IActionResult GetAll(int page=1)
        {
            var data = _context.Products.AsQueryable();
            data=data.Skip((page-1)*5).Take(5).AsQueryable();
                
                
                
           var result= data.Select(x=>new ProductGetDto
            {
                Id= x.Id,
                Name= x.Name,
                Price= x.Price,
                Brand=new BrandGetForProduct()
                {
                    Id=x.Id,
                    Name= x.Name,
                }
            });
            return Ok(data);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Products.Include(x=>x.Brand).FirstOrDefault(x=>x.Id==id);
            if (data==null)
            {
                return NotFound();
            }
            var dbodata = new ProductGetDto() { 
            Id=data.Id,
            Name=data.Name,
            Price=data.Price,
            Brand=new BrandGetForProduct()
            {
                Id=data.Brand.Id,
                Name=data.Brand.Name
            }
            
            };

            return Ok(dbodata);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Create(ProductCreateDbo dbo)
        {
            if (!_context.Brands.Any(x=>x.Id==dbo.BrandId))
            {
                ModelState.AddModelError("BrandId", "There is no Brand Id!");
                return BadRequest(ModelState);
            }
            var pro = new Product()
            {
                Name = dbo.Name,
                Price = dbo.Price,
                CostPrice = dbo.CostPrice,
                BrandId = dbo.BrandId,
            };
            _context.Products.Add(pro);
            _context.SaveChanges();
            return Ok(pro);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(int id,ProductEditDbo dbo)
        {
            var data=_context.Products.Include(x=>x.Brand).FirstOrDefault(x=>x.Id==id);
            if (data == null) return NotFound();
            if (dbo.BrandId!=data.BrandId && !_context.Brands.Any(x => x.Id == dbo.BrandId))
            {
                ModelState.AddModelError("BrandId", "There is no Brand Id!");
                return BadRequest(ModelState);
            }
            data.Name= dbo.Name;
            data.Price= dbo.Price;
            data.CostPrice= dbo.CostPrice;
            data.BrandId= dbo.BrandId;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Products.Include(x => x.Brand).FirstOrDefault(x => x.Id == id);
            if (data == null) return NotFound();
            _context.Products.Remove(data);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
