using EcommerceBlazor.Shared;

namespace EcommerceBlazor.Client.Services.ProductService
{
    public interface IProductService
    {
        //By creating the list here I ensure that
        //I will not create Lists everywhere in the program so
        //The code will look way cleaner
        List<Product> Products { get; set; }
        Task GetProducts();
        Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
