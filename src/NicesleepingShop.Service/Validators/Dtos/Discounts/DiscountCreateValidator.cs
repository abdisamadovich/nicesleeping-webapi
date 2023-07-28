using FluentValidation;
using NicesleepingShop.Service.Dtos.Discounts;

namespace NicesleepingShop.Service.Validators.Dtos.Discounts
{
    public class DiscountCreateValidator : AbstractValidator<DiscountCreateDto>
    {
        public DiscountCreateValidator()
        {
            RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");
            
            RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(3).WithMessage("Description must be more than 3 characters")
            .MaximumLength(50).WithMessage("Description must be less than 50 characters");

            //RuleFor(dto => dto.Percentage).NotNull().NotEmpty().WithMessage("Percentage field is required!");
       






        }
    }
}
