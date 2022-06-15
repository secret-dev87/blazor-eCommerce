using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        //Adding DbContext using DI
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //detects a call and returns data by using Ok method
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //Via DbContext access Products table in the DB to return the data
            var products = await _context.Products.ToListAsync(); 
            return Ok(products);
        }
    }
}
