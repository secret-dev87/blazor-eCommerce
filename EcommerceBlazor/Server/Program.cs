global using EcommerceBlazor.Shared;
global using Microsoft.EntityFrameworkCore;
global using EcommerceBlazor.Server.Data;
global using EcommerceBlazor.Server.Services.ProductService;
global using EcommerceBlazor.Server.Services.CategoryService;
global using EcommerceBlazor.Server.Services.CartService;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

// Register DataContext and Configure it for the SqlServer
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This Service allows to use ProductService as implementation of IProductService methods
//As soon as IProductService was Injected somewhere in the program.
//By placing it here I can change ProductService to any other Service I create
//So the implementations of Interface methods will also change
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();

var app = builder.Build();

app.UseSwaggerUI(); //Swagger

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger(); //Swagger

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
