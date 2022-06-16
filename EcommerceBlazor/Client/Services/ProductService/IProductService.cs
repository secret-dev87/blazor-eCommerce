namespace EcommerceBlazor.Client.Services.ProductService
{
    public interface IProductService
    {
        //by creating the list here I ensure that
        //I will not create Lists everywhere in the program so
        //the code will look way cleaner
        List<Product> Products { get; set; }
        Task GetProducts();
    }
}
