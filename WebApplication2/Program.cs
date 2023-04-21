using Persistence.Contexts;
using Service.Registrations;
using Service.Tables;
using Model.Registrations;
using Model.Tables;
using Persistence.DAL.Registrations;
using Persistence.DAL.Tables;
using WebApplication2.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddDbContext<EFContext>();
builder.Services.AddScoped<Manufacturer>();
builder.Services.AddScoped<ManufacturerDAL>();
builder.Services.AddScoped<ManufacturerService>();
builder.Services.AddScoped<Product>();
builder.Services.AddScoped<ProductDAL>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<Category>();
builder.Services.AddScoped<CategoryDAL>();
builder.Services.AddScoped<CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{   
    app.UseMiddleware<ErrorHandler>();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "error",
    pattern: "Error/{statusCode:int}",
    defaults: new { controller = "Error", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

