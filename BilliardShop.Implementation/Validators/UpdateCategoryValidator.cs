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
    public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public UpdateCategoryValidator(BilliardShopContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                    .MinimumLength(2).WithMessage("Name must have minimum 2 characters.")
                    .MaximumLength(50).WithMessage("Name must have maximum 50 characters.")

                    .Must((dto, name) => !context.Categories.Any(x => x.Name == name && x.Id != dto.Id))
                    .WithMessage(x => $"Category with the name of {x.Name} already exists.");
                });
        }
    }
}
