using AutoMapper;
using BilliardShop.Application;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Exceptions;
using BilliardShop.Domain;
using BilliardShop.EfDataAccess;
using BilliardShop.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Commands
{
    public class EfUpdateOrderCommand : IUpdateOrderCommand
    {
        private readonly BilliardShopContext _context;
        private readonly CreateOrderValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EfUpdateOrderCommand(BilliardShopContext context, IMapper mapper, CreateOrderValidator validator, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 24;

        public string Name => "Update Order using EF";

        public void Execute(OrderDto request)
        {
            var order = _context.Orders.Include(x => x.OrderLines).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == request.Id);

            if (order == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Order));
            }

            _validator.ValidateAndThrow(request);

            if (order.UserId != _actor.Id)
            {
                throw new UpdateOrderException("You are not allowed to change this order.");
            }

            order.Address = request.Address;
            order.OrderDate = request.OrderDate;

            foreach (var item in request.OrderLines)
            {
                var product = _context.Products.Find(item.ProductId);

                int x;

                foreach (var orderitem in order.OrderLines)
                {
                    if (orderitem.Id == item.Id)
                    {
                        if (item.Quantity < orderitem.Quantity)
                        {
                            x = orderitem.Quantity - item.Quantity;
                            product.Quantity += x;
                        }
                        if (item.Quantity > orderitem.Quantity)
                        {
                            x = item.Quantity - orderitem.Quantity;
                            product.Quantity -= x;
                        }

                        orderitem.ProductId = item.ProductId;
                        orderitem.Quantity = item.Quantity;
                        orderitem.Price = product.Price;
                    }
                }
            }

            _context.SaveChanges();
        }
    }

}
