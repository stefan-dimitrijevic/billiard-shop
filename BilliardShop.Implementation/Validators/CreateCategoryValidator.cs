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
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(BilliardShopContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                    .MinimumLength(2).WithMessage("Name must have minimum 2 characters.")
                    .MaximumLength(50).WithMessage("Name must have maximum 50 characters.")

                    .Must(name => !context.Categories.Any(x => x.Name == name))
                    .WithMessage(x => $"Category with the name of {x.Name} already exists.");
                });
        }
    }
}
