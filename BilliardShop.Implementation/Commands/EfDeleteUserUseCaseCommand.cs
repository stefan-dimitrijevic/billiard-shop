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
    public class EfDeleteUserUseCaseCommand : IDeleteUserUseCaseCommand
    {
        private readonly BilliardShopContext _context;

        public EfDeleteUserUseCaseCommand(BilliardShopContext context)
        {
            _context = context;
        }

        public int Id => 30;

        public string Name => "Delete User Use case using EF";

        public void Execute(int request)
        {
            var useCase = _context.UserUseCases.Find(request);

            if (useCase == null)
            {
                throw new EntityAlreadyExistsException(request, typeof(UserUseCase));
            }

            _context.Remove(useCase);
            _context.SaveChanges();
        }
    }

}
