

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

        public async Task GetProducts()
        {
            var result =                               //same name as a name of a controller I try to access
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products"); //get call
            if (result != null && result.Data != null)
                Products = result.Data;
        }
    }
}
