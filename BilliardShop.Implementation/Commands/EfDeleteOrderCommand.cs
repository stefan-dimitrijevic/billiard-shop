using BilliardShop.Application.Commands;
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
    public class EfDeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly BilliardShopContext _context;

        public EfDeleteOrderCommand(BilliardShopContext context)
        {
            _context = context;
        }

        public int Id => 25;

        public string Name => "Cancel Order using EF";

        public void Execute(int request)
        {
            var order = _context.Orders.Include(x => x.OrderLines).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == request);

            if (order == null)
            {
                throw new EntityNotFoundException(request, typeof(Order));
            }

            if (order.Status == OrderStatus.Canceled)
            {
                throw new EntityNotFoundException(request, typeof(Order));
            }

            order.Status = OrderStatus.Canceled;
            
            foreach (var item in order.OrderLines)
            {
                item.Product.Quantity += item.Quantity;
            }
            _context.SaveChanges();
        }
    }

}
