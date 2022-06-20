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
            //Look for product by Id, as a parameter, in a database
            var product = await _context.Products.FindAsync(productId);
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
                Data = await _context.Products.ToListAsync()
            };

            return response;
        }
    }
}
