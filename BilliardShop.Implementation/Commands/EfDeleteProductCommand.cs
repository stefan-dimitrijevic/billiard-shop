using BilliardShop.Application.Commands;
using BilliardShop.Application.Exceptions;
using BilliardShop.Domain;
using BilliardShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Commands
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly BilliardShopContext _context;
        public EfDeleteProductCommand(BilliardShopContext context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Delete Product using EF";

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFoundException(request, typeof(Product));
            }

            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow;
            product.IsActive = false;

            _context.SaveChanges();
        }
    }

}
