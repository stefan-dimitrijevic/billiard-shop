using AutoMapper;
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
    public class EfCreateUserUseCaseCommand : ICreateUserUseCaseCommand
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;
        private readonly CreateUserUseCaseValidator _validator;

        public EfCreateUserUseCaseCommand(BilliardShopContext context, IMapper mapper, CreateUserUseCaseValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 27;

        public string Name => "Create new User Use case using EF";

        public void Execute(UserUseCaseDto request)
        {
            _validator.ValidateAndThrow(request);

            var useCase = _mapper.Map<UserUseCase>(request);

            _context.UserUseCases.Add(useCase);
            _context.SaveChanges();
        }
    }

}
