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

        //by Injecting IProductService here I call a service
        //which I've added in Program.cs file and it uses exactly ProductService service
        //which may be replaced there by any other newly created service.
        //so in fact Interfaces allow to do DI convinient
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //detects a request and returns data by using Ok method
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            //because of DI, here ProductService solution is used, not Interface's one
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }
    }
}
