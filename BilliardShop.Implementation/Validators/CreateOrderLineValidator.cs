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
    public class CreateOrderLineValidator : AbstractValidator<OrderLineDto>
    {
        private readonly BilliardShopContext _context;
        public CreateOrderLineValidator(BilliardShopContext context)
        {
            _context = context;

            RuleFor(x => x.ProductId)
               .Must(ProductExists).WithMessage(x => $"Stock with an id of {x.ProductId} doesn't exist.")
               .DependentRules(() =>
               {
                   RuleFor(x => x.Quantity)

                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                    .LessThan(6).WithMessage("The maximum quantity must not exceed 5.")

                    .Must(StockQuantityAvailable).WithMessage("Quantity is unavailable.");
               });

        }
        private bool ProductExists(int? productId)
        {
            return _context.Products.Any(x => x.Id == productId);
        }
        private bool StockQuantityAvailable(OrderLineDto dto, int quantity)
        {
            return _context.Products.Find(dto.ProductId).Quantity >= quantity;
        }
    }

}
