using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Service.Dtos.Products;
using NicesleepingShop.Service.Interfaces.Products;
using NicesleepingShop.Service.Validators.Dtos.Categories;
using NicesleepingShop.Service.Validators.Dtos.Products;
using System.Formats.Asn1;

namespace NicesleepingShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly int maxPageSize = 30;

        public ProductsController(IProductService product)
        {
               this._productService = product;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
        {
            var createValidator = new ProductCreateValidator();
            var result = createValidator.Validate(dto);
            if (result.IsValid) return Ok(await _productService.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long productId)
        {
            return Ok(await _productService.DeleteAsync(productId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        {
            return Ok(await _productService.GetAllAsync(new PaginationParams(page, maxPageSize)));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByIdAsync(long categoryId)
        {
            return Ok(await _productService.GetByIdAsync(categoryId));
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
        {
            return Ok(await _productService.CountAsync());
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAsync(long productId, [FromForm] ProductUpdateDto dto)
        {
            var updateValidator = new ProductUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _productService.UpdateAsync(productId, dto));
            else return BadRequest(validationResult.Errors);
        }

    }
}
