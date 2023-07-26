using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Service.Dtos.Categories;
using NicesleepingShop.Service.Interfaces.Categories;
using NicesleepingShop.Service.Validators.Dtos.Categories;

namespace NicesleepingShop.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    private readonly int maxPageSize = 30;
    public CategoriesController(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
    {
        return Ok(await _categoryService.GetAllAsync(new PaginationParams(page, maxPageSize)));
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


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto category)
    {
        var createValidator = new CategoryCreateValidator();
        var result = createValidator.Validate(category);
        if(result.IsValid) return Ok(await _categoryService.CreateAsync(category)); 
        else return BadRequest(result.Errors);
    }


    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
    {
        var updateValidator = new CategoryUpdateValidator();
        var result = updateValidator.Validate(dto);
        if (result.IsValid) return Ok(await _categoryService.UpdateAsync(categoryId, dto));
        else return BadRequest(result.Errors);

    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
    {
        return Ok(await _categoryService.DeleteAsync(categoryId));
    }

}
