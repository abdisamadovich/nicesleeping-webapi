using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
