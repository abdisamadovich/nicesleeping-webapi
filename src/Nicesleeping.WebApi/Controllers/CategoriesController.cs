using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Service.Dtos.Categories;
using NicesleepingShop.Service.Interfaces.Categories;

namespace NicesleepingShop.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly int maxPageSize = 2;
    public CategoriesController(ICategoryService categoryService)
    {
        this._categoryService = categoryService;

    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto category)
    {
        return Ok(await _categoryService.CreateAsync(category));
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
    {
        return Ok(await _categoryService.GetByIdAsync(categoryId));
    }

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
    {
        return Ok(await _categoryService.CountAsync());
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
    {
        return Ok(await _categoryService.GetAllAsync(new PaginationParams(page, maxPageSize )));
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
    {
        return Ok(await _categoryService.DeleteAsync(categoryId));
    }
}
