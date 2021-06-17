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
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly BilliardShopContext _context;

        public EfDeleteCategoryCommand(BilliardShopContext context)
        {
            _context = context;
        }

        public int Id => 10;

        public string Name => "Delete Category using EF";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow;
            category.IsActive = false;

            _context.SaveChanges();
        }
    }

}
