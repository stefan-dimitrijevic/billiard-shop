using BilliardShop.Application.DataTransfer;
using BilliardShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Validators
{
    public class CreateBrandValidator : AbstractValidator<BrandDto>
    {
        public CreateBrandValidator(BilliardShopContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                    .MinimumLength(2).WithMessage("Name must have minimum 2 characters.")
                    .MaximumLength(30).WithMessage("Name must have maximum 20 characters.")

                    .Must(name => !context.Brands.Any(x => x.Name == name))
                    .WithMessage(x => $"Brand with the name of {x.Name} already exists.");
                });
        }
    }
}
