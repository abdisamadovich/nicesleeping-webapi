using Microsoft.AspNetCore.Mvc;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using NicesleepingShop.Service.Dtos.Users;
using NicesleepingShop.Service.Interfaces.Users;
using NicesleepingShop.Service.Validators.Dtos.Users;

namespace NicesleepingShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly int maxPageSize = 30;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        {
            return Ok(await _userService.GetAllAsync(new PaginationParams(page, maxPageSize)));
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long userId)
        {
            return Ok(await _userService.GetByIdAsync(userId));

        }


        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
        {
            return Ok(await _userService.CountAsync());
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto user)
        {
            var createValidator = new UserCreateValidator();
            var result = createValidator.Validate(user);
            if(result.IsValid) return Ok(await _userService.CreateAsync(user)); 
            else return BadRequest(result.Errors);
        }


        [HttpPut("userId")]
        public async Task<IActionResult> UpdateAsync(long Id, [FromForm] UserUpdateDto userUpdateDto)
        {
            var updateValidator = new UserUpdateValidator();
            var vrResult = updateValidator.Validate(userUpdateDto);
            if (vrResult.IsValid) return Ok(await _userService.UpdateAsync(Id, userUpdateDto));
            else return BadRequest(vrResult.Errors);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(long userId)
        {
            return Ok(await _userService.DeleteAsync(userId));
        }


    }
}
