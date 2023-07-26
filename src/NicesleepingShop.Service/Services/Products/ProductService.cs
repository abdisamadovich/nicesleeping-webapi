using NicesleepingShop.DataAccess.Interfaces.Products;
using NicesleepingShop.Domain.Entities.Products;
using NicesleepingShop.Service.Common.Helpers;
using NicesleepingShop.Service.Dtos.Products;
using NicesleepingShop.Service.Interfaces.Common;
using NicesleepingShop.Service.Interfaces.Products;

namespace NicesleepingShop.Service.Services.Products;

public class ProductService : IProductService
{
    private IProductRepository _repository;
    private IFileService _fileservice;

    public ProductService(IProductRepository productRepository, IFileService fileService)
    {
        this._repository = productRepository;
        this._fileservice = fileService;
    }
    public async Task<bool> CreateAsync(ProductCreateDto dto)
    {
        string imagepath = await _fileservice.UploadImageAsync(dto.Image);
        Product product = new Product();
        product.CategoryId = dto.CategoryId;
        product.Name = dto.Name;
        product.Status = dto.Status;
        product.ImagePath = imagepath;
        product.UnitPrice = dto.UnitPrice;
        product.Description = dto.Description;
        product.CreatedAt = product.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.CreateAsync(product);
        return dbResult > 0;
         
    }
}
