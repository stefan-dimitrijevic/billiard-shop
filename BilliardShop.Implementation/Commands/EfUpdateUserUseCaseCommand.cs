using AutoMapper;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Exceptions;
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
    public class EfUpdateUserUseCaseCommand : IUpdateUserUseCaseCommand
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;
        private readonly CreateUserUseCaseValidator _validator;

        public EfUpdateUserUseCaseCommand(BilliardShopContext context, IMapper mapper, CreateUserUseCaseValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 29;

        public string Name => "Update Use case using EF";

        public void Execute(UserUseCaseDto request)
        {
            var useCase = _context.UserUseCases.Find(request.Id);

            if (useCase == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(UserUseCase));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, useCase);
            _context.SaveChanges();
        }
    }

}
