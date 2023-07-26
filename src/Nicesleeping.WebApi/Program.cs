using NicesleepingShop.DataAccess.Interfaces.Categories;
using NicesleepingShop.DataAccess.Interfaces.Products;
using NicesleepingShop.DataAccess.Repositories.Categories;
using NicesleepingShop.DataAccess.Repositories.Products;
using NicesleepingShop.Service.Interfaces.Categories;
using NicesleepingShop.Service.Interfaces.Common;
using NicesleepingShop.Service.Interfaces.Products;
using NicesleepingShop.Service.Services.Categories;
using NicesleepingShop.Service.Services.Common;
using NicesleepingShop.Service.Services.Products;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//>
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
//>

//development, stagging, production
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
