

namespace EcommerceBlazor.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        //http is used to request calls (CRUD)
        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        //calls a controller and get a product by Id
        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/{productId}");
            return result;
        }

        public async Task GetProducts()
        {
            var result =                               //same name as the name of a controller I try to access
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products"); //get call
            if (result != null && result.Data != null)
                Products = result.Data;
        }
    }
}
