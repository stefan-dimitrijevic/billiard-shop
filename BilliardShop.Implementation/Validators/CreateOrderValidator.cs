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
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {

        public CreateOrderValidator(BilliardShopContext context)
        {
            RuleFor(x => x.OrderDate)
                .GreaterThan(DateTime.Now.AddDays(1)).WithMessage("Order date must be greater than 2 days from today.")
                .LessThan(DateTime.Now.AddDays(30)).WithMessage("Order date must be less than 30 days from today.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Address)
                    .MinimumLength(2).WithMessage("Address must have minimum 2 characters.")
                    .MaximumLength(50).WithMessage("Address must have maximum 50 characters.");
                });


            RuleFor(x => x.OrderLines)
                .NotEmpty().WithMessage("Order must contain at least one item.")
                .Must(i => i.Select(x => x.ProductId).Distinct().Count() == i.Count())
                .WithMessage("Duplicate products are not allowed.")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.OrderLines).SetValidator(new CreateOrderLineValidator(context));
                });
        }

    }

}
