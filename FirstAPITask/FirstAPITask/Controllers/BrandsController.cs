using FirstAPITask.DAL;
using FirstAPITask.DTOS.Brands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public BrandsController(APIDbContext context) 
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var datas=_context.Brands.Include(x=>x.Products).ToList();
            var result=datas.Select(x => new BrandGetDbo()
            {
                Id = x.Id,
                Name = x.Name,
                Products = x.Products,
            });
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var data=_context.Brands.Include(_x => _x.Products).FirstOrDefault(x => x.Id == id);
            if (data==null)
            {
                return NotFound();
            }
            var result = new BrandGetDbo();
            result.Id = id;
            result.Name = data.Name;
            result.Products = data.Products;
            return Ok(result);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Create(BrandCreateDbo dbo)
        {
            var result = new Entities.Brand();
            result.Name=dbo.Name;
            result.Products = new List<Entities.Product>();
            _context.Brands.Add(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(int id, BrandEditDbo dbo)
        {
            var data = _context.Brands.Find(id);
            if (data==null)
            {
                return NotFound();
            }
            data.Name=dbo.Name;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Brands.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.Brands.Remove(data);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
