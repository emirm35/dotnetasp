using StoreApp.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();


/*  */
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Storeapp.Session";

    // Oturum zaman aşımı
    options.IdleTimeout = TimeSpan.FromMinutes(10);

});

// bana class verme , session'dan kartı ver
/* builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c)); */
builder.Services.AddAutoMapper(typeof(Program));






/* Extension methods  */

builder.Services.ConfigureRouting();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();

//Reponun bağlanması
/* builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
}); */

var app = builder.Build();


app.UseSession();

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();



app.ConfigureAndCheckMigration();

//Çoklu routing
app.UseEndpoints(endpoints =>
{

    //Admin Area
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=index}/{id?}"
    );



    //User
    endpoints.MapControllerRoute(
        name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");


    endpoints.MapRazorPages();
});









app.Run();
