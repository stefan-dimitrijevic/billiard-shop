using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Exceptions;
using BilliardShop.Domain;
using BilliardShop.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Commands
{
    public class EfChangeOrderStatusCommand : IChangeOrderStatusCommand
    {
        private readonly BilliardShopContext _context;

        public EfChangeOrderStatusCommand(BilliardShopContext context)
        {
            _context = context;
        }

        public int Id => 26;

        public string Name => "Change Order status using EF";

        public void Execute(ChangeOrderStatusDto request)
        {
            var order = _context.Orders.Include(x => x.OrderLines).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == request.OrderId);

            if (order == null)
            {
                throw new EntityNotFoundException(request.OrderId, typeof(Order));
            }

            if (order.Status == OrderStatus.Delivered || order.Status == OrderStatus.Canceled)
            {
                throw new ChangeOrderStatusException("Can't change status of delivered or canceled order.");
            }

            if (order.Status == OrderStatus.Shipped)
            {
                if (request.Status == OrderStatus.Delivered || request.Status == OrderStatus.Canceled)
                {
                    order.Status = request.Status;

                    if (request.Status == OrderStatus.Canceled)
                    {
                        foreach (var item in order.OrderLines)
                        {
                            item.Product.Quantity += item.Quantity;
                        }
                    }
                    _context.SaveChanges();
                }
                else if (request.Status == OrderStatus.Shipped)
                {
                    _context.SaveChanges();
                }
                else
                {
                    throw new ChangeOrderStatusException("Order can't be transitioned from recieved back to recieved.");
                }
            }

            if (order.Status == OrderStatus.Recieved)
            {
                if (request.Status == OrderStatus.Shipped || request.Status == OrderStatus.Canceled)
                {
                    order.Status = request.Status;

                    if (request.Status == OrderStatus.Canceled)
                    {
                        foreach (var item in order.OrderLines)
                        {
                            item.Product.Quantity += item.Quantity;
                        }
                    }

                    if (request.Status == OrderStatus.Shipped)
                    {
                        order.ShippedDate = DateTime.UtcNow;
                    }
                    _context.SaveChanges();
                }
                else if (request.Status == OrderStatus.Recieved)
                {
                    _context.SaveChanges();
                }
                else
                {
                    throw new ChangeOrderStatusException("Order can't be transitioned from recieved to delivered directly.");
                }
            }
        }
    }

}
