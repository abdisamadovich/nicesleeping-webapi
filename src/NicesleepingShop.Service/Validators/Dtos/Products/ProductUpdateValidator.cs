﻿using FluentValidation;
using NicesleepingShop.Service.Common.Helpers;
using NicesleepingShop.Service.Dtos.Products;

namespace NicesleepingShop.Service.Validators.Dtos.Products;

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(20).WithMessage("Description field is required!");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 3;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}