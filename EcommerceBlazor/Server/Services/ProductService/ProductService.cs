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
                .ThenInclude(v => v.ProductType) //using variants it loads types
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
                                         //because I don't need types on category page
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {

            var pageResults = 2f; //num of results per page
            //calc number of pages according to pageResults
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
            //filter results to pages
            var products = await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                ||
                                p.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Variants)
                                //E.g if I try to access page 3 I skip first 4 products
                                //((3 - 1)*2=4) and Take 2 next products and list them
                                //So in the end I get filtered page 3
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
				}
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                                                       //same as lowercase everything manually
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    //Adds title to the list if Title contains searchText
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                        //take out all punctuation from the list of products
                        //and place it into an array
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                        //split all words from the list into separate
                        //"list" of words (using Select) and
                        //delete punctuation (from the array created above)
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Featured)
                .Include(p => p.Variants)
                .ToListAsync()
            };

            return response;
        }

        //Filter to search through Titles and Descriptions by given searchText
        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                ||
                                p.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Variants)
                                .ToListAsync();
        }
	}
}
