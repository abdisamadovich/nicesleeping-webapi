using NicesleepingShop.DataAccess.Interfaces.Categories;
using NicesleepingShop.DataAccess.Repositories.Categories;
using NicesleepingShop.Service.Interfaces.Categories;
using NicesleepingShop.Service.Interfaces.Common;
using NicesleepingShop.Service.Services.Categories;
using NicesleepingShop.Service.Services.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//>
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//>

//development, stagging, production
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
