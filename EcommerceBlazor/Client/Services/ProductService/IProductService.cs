﻿using EcommerceBlazor.Shared;

namespace EcommerceBlazor.Client.Services.ProductService
{
    public interface IProductService
    {
        //to rerender
        event Action ProductsChanged;

        //By creating the list here I ensure that
        //I will not create Lists everywhere in the program so
        //The code will look way cleaner
        List<Product> Products { get; set; }
        List<Product> AdminProducts { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchText, int page);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
        Task GetAdminProducts();
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
