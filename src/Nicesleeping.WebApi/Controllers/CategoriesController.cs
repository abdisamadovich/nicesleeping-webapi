using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Service.Dtos.Categories;

namespace NicesleepingShop.WebApi.Controllers; 

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto category)
    {
        return Ok();
    }
}
