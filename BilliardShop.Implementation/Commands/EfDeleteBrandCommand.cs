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
    public class EfDeleteBrandCommand : IDeleteBrandCommand
    {
        private readonly BilliardShopContext _context;
        public EfDeleteBrandCommand(BilliardShopContext context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "Delete Brand using EF";

        public void Execute(int request)
        {
            var brand = _context.Brands.Find(request);

            if (brand == null)
            {
                throw new EntityNotFoundException(request, typeof(Brand));
            }

            brand.IsDeleted = true;
            brand.DeletedAt = DateTime.UtcNow;
            brand.IsActive = false;

            _context.SaveChanges();
        }
    }

}
