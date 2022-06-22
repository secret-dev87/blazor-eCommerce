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
        //so in fact Interfaces allow to do DI convenient
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet] //All products
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
                                               //func from ProductService
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")] //Product Details
        public async Task<ActionResult<ServiceResponse<Product>>> GetProducts(int productId)
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")] //Category
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText)
        {
            var result = await _productService.SearchProducts(searchText);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(result);
        }

    }
}
