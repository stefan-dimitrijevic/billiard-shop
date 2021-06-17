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
    public class EfUpdateBrandCommand : IUpdateBrandCommand
    {
        private readonly BilliardShopContext _context;
        private readonly UpdateBrandValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateBrandCommand(BilliardShopContext context, UpdateBrandValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Update Brand using EF";

        public void Execute(BrandDto request)
        {
            var brand = _context.Brands.Find(request.Id);

            if (brand == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Brand));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, brand);
            _context.SaveChanges();
        }
    }

}
