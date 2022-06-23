

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
        public string Message { get; set; } = "Loading Products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

		public event Action ProductsChanged;

        //calls a controller and get a product by Id
        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            //if no categoryUrl - all products, if url - category by its categoryUrl
            var result =
                categoryUrl == null ? 
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/products/category/{categoryUrl}");                ; 
            if (result != null && result.Data != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
                Message = "No products found.";

            //After using GetProducts method in a component
            //The event will Invoke and subscribe to some other method
            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/products/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/products/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No products found.";
            ProductsChanged?.Invoke();
        }
    }
}
