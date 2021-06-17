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
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly BilliardShopContext _context;

        public EfDeleteUserCommand(BilliardShopContext context)
        {
            _context = context;
        }

        public int Id => 20;

        public string Name => "Delete User using EF";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            user.IsActive = false;

            _context.SaveChanges();
        }
    }

}
