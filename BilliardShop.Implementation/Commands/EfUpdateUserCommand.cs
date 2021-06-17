using AutoMapper;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Exceptions;
using BilliardShop.Application.Hash;
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
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly BilliardShopContext _context;
        private readonly UpdateUserValidator _validator;
        private readonly IHashPassword _hashPassword;
        private readonly IMapper _mapper;

        public EfUpdateUserCommand(BilliardShopContext context, IMapper mapper,
            UpdateUserValidator validator, IHashPassword hashPassword)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _hashPassword = hashPassword;
        }
        public int Id => 19;

        public string Name => "Update User using EF";

        public void Execute(UserDto request)
        {
            var user = _context.Users.Find(request.Id);

            request.Password = _hashPassword.ComputeSha256Hash(request.Password);

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, user);
            _context.SaveChanges();
        }
    }
}
