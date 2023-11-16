using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

//Reponun bağlanması
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
});

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}"
);








app.Run();
