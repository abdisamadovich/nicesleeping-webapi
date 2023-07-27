using Microsoft.AspNetCore.Mvc;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Service.Dtos.Discounts;
using NicesleepingShop.Service.Interfaces.Discounts;
using NicesleepingShop.Service.Validators.Dtos.Discounts;

namespace NicesleepingShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        private readonly int maxPageSize = 30;
        public DiscountController(IDiscountService discountService)
        {
            this._discountService = discountService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        {
            return Ok(await _discountService.GetAllAsync(new PaginationParams(page, maxPageSize)));
        }


        [HttpGet("{dicountId}")]
        public async Task<IActionResult> GetByIdAsync(long dicountId)
        {
            return Ok(await _discountService.GetByIdAsync(dicountId));
        }




        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] DiscountCreateDto dis)
        {
           
            var cv = new DiscountCreateValidator();
            var res = cv.Validate(dis);
            if(res.IsValid) return Ok(await _discountService.CreateAsync(dis));
            else return BadRequest(res.Errors);
        }



        [HttpDelete("{dicountId}")]
        public async Task<IActionResult> DeleteAsync(long dicountId)
        {
            return Ok(await _discountService.DeleteAsync(dicountId));
        }
    }
}
