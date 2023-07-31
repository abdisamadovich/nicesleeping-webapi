using NicesleepingShop.DataAccess.Interfaces.Categories;
using NicesleepingShop.DataAccess.Interfaces.Categories.Discounts;
using NicesleepingShop.DataAccess.Interfaces.Products;
using NicesleepingShop.DataAccess.Interfaces.Users;
using NicesleepingShop.DataAccess.Repositories.Categories;
using NicesleepingShop.DataAccess.Repositories.Discounts;
using NicesleepingShop.DataAccess.Repositories.Products;
using NicesleepingShop.DataAccess.Repositories.Users;
using NicesleepingShop.Service.Interfaces.Auth;
using NicesleepingShop.Service.Interfaces.Categories;
using NicesleepingShop.Service.Interfaces.Common;
using NicesleepingShop.Service.Interfaces.Discounts;
using NicesleepingShop.Service.Interfaces.Products;
using NicesleepingShop.Service.Interfaces.Users;
using NicesleepingShop.Service.Services.Auth;
using NicesleepingShop.Service.Services.Categories;
using NicesleepingShop.Service.Services.Common;
using NicesleepingShop.Service.Services.Discounts;
using NicesleepingShop.Service.Services.Products;
using NicesleepingShop.Service.Services.Users;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

//>
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
//>

//development, stagging, production
var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
