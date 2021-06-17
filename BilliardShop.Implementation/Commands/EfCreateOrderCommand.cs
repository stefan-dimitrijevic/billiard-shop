using AutoMapper;
using BilliardShop.Application;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Domain;
using BilliardShop.EfDataAccess;
using BilliardShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Commands
{
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private readonly BilliardShopContext _context;
        private readonly CreateOrderValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EfCreateOrderCommand(BilliardShopContext context, CreateOrderValidator validator, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 21;

        public string Name => "Create new Order using EF";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order
            {
                UserId = _actor.Id,
                Address = request.Address,
                OrderDate = request.OrderDate,
            };

            foreach (var item in request.OrderLines)
            {

                var product = _context.Products.Find(item.ProductId);

                product.Quantity -= item.Quantity;

                order.OrderLines.Add(new OrderLine
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price
                });
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }

}
