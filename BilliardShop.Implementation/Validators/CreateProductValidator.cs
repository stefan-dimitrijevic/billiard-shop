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
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        private BilliardShopContext _context;
        public CreateProductValidator(BilliardShopContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                    .MinimumLength(2).WithMessage("Name must have minimum 2 characters.")
                    .MaximumLength(50).WithMessage("Name must have maximum 50 characters.")

                    .Must(name => !context.Products.Any(x => x.Name == name))
                    .WithMessage(x => $"Product with the name of {x.Name} already exists.");
                });


            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Description)
                    .MinimumLength(10).WithMessage("Description must have minimum 10 characters.")
                    .MaximumLength(1000).WithMessage("Description must have maximum 1000 characters.");
                });

            RuleFor(x => x.BrandId)
                .NotEmpty().WithMessage("Brand is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.BrandId)
                    .Must(BrandExists).WithMessage(x => $"Brand with an id of {x.BrandId} doesn't exist.");
                });

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CategoryId)
                    .Must(CategoryExists).WithMessage(x => $"Category with an id of {x.CategoryId} doesn't exist.");
                });
        }

        private bool BrandExists(int brandId)
        {
            return _context.Brands.Any(x => x.Id == brandId);
        }
        private bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(x => x.Id == categoryId);
        }
    }

}
