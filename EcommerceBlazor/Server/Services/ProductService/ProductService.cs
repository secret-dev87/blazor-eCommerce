namespace EcommerceBlazor.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();

            //adds variants and types to be seen on P_Details page
            //and returns product by Id
            var product = await _context.Products
                .Include(p => p.Variants) //used to load variants
                .ThenInclude(v => v.ProductType) //using variants it loads types of Products
                .FirstOrDefaultAsync(p => p.Id == productId); //if first - returns product by given Id
                                                             //if default - line 24

            if (product == null)
            {
                //The reason to create SResponse was in
                //The ability to rapidly configure
                //The responses from the server and provide extra info as a Message
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                //If all correct - set product as response Data
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                //only variants because I don't need types on Index page
                Data = await _context.Products.Include(p => p.Variants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .Include(p => p.Variants) //adds only variants
                                         //because I don't need types on category pages
                .ToListAsync()
            };

            return response;
        }

        //Search by Title and Discription
        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                ||
                p.Description.ToLower().Contains(searchText.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync()
            };

            return response;
        }
    }
}
