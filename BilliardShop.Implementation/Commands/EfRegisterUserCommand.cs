using AutoMapper;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Email;
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
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly BilliardShopContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;
        private readonly IHashPassword _hashPassword;
        private readonly IMapper _mapper;

        public EfRegisterUserCommand(BilliardShopContext context, RegisterUserValidator validator,
            IEmailSender sender, IHashPassword hashPassword, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
            _hashPassword = hashPassword;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "User registration using EF";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            request.Password = _hashPassword.ComputeSha256Hash(request.Password);

            var user = _mapper.Map<Domain.User>(request);

            _context.Users.Add(user);
            _context.SaveChanges();

            var useCases = new List<int> { 2, 3, 7, 8, 12, 13, 17, 18, 21, 23, 24, 25 };

            List<UserUseCase> userUseCases = new List<UserUseCase>();

            foreach (var item in useCases)
            {
                userUseCases.Add(new UserUseCase
                {
                    UseCaseId = item,
                    UserId = user.Id
                });
            }

            _context.UserUseCases.AddRange(userUseCases);
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                SendTo = request.Email,
                Subject = "Best Buy Registration",
                Body = "<h1>Successful registration</h1>"
            });
        }
    }

}
