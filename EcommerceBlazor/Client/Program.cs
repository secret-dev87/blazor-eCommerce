global using EcommerceBlazor.Shared;
global using System.Net.Http.Json;
global using EcommerceBlazor.Client.Services.ProductService;
global using EcommerceBlazor.Client.Services.CategoryService;
global using EcommerceBlazor.Client.Services.CartService;
global using EcommerceBlazor.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using EcommerceBlazor.Client.Services.OrderService;
global using EcommerceBlazor.Client.Services.AdderessService;
global using EcommerceBlazor.Client.Services.ProductTypeService;
using EcommerceBlazor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();