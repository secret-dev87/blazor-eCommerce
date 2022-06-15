using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//thin controller which is used solely to recieve requests
//from a client and call a service which deals with logic
namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //detects a request and returns data by using Ok method
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            //Via DbContext access Products table in the DB to return the data
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }
    }
}
