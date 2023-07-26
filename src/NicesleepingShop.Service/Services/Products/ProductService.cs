using NicesleepingShop.DataAccess.Interfaces.Products;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Domain.Entities.Products;
using NicesleepingShop.Domain.Exception.Categories;
using NicesleepingShop.Domain.Exception.Files;
using NicesleepingShop.Domain.Exception.Products;
using NicesleepingShop.Service.Common.Helpers;
using NicesleepingShop.Service.Dtos.Categories;
using NicesleepingShop.Service.Dtos.Products;
using NicesleepingShop.Service.Interfaces.Common;
using NicesleepingShop.Service.Interfaces.Products;
using NicesleepingShop.Service.Services.Common;

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

    public async Task<long> CountAsync()
    {
        return await _repository.CountAsync();
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

    public async Task<bool> DeleteAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();
        else
        {
            await _fileservice.DeleteImageAsync(product.ImagePath);
            var result = await _repository.DeleteAsync(productId);
            return result > 0;
        }
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        var product = await _repository.GetAllAsync(@params);
        return product;
    }

    public async Task<Product> GetByIdAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();
        else return product;
    }

    public async Task<bool> UpdateAsync(long ProductId, ProductUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(ProductId);
        if (product is null) throw new ProductNotFoundException();

        //Parse new items to category
        product.CategoryId = dto.categoryId;
        product.Name = dto.Name;
        product.Status = dto.status;

        if (dto.Image is not null)
        {
            // delete old image
            var deleteResult = await _fileservice.DeleteImageAsync(product.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileservice.UploadImageAsync(dto.Image);

            // parse new path to category
            product.ImagePath = newImagePath;
        }


        product.Description = dto.Description;
        product.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(ProductId, product);
        return dbResult > 0;
    }

    
}
