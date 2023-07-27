using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;
using NicesleepingShop.Service.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicesleepingShop.Service.Validators.Dtos.Users
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required")
            .MaximumLength(50).WithMessage("Firstname must be less than 30 characters");

            RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required")
                .MaximumLength(50).WithMessage("Lastname must be less than 30 characters");

            RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
            
                .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

            

            RuleFor(dto => dto.Address).NotNull().NotEmpty().WithMessage("Address is required!")
                .MaximumLength(100).WithMessage("Address must be less than 100 characters");

            RuleFor(dto => dto.PasswordHash).NotNull().NotEmpty().WithMessage("Password is requuired")
                .Must(password => PasswordValidator.IsStrongPassword(password).isValid).WithMessage("Password is not strong password!");
        }
    }
}
