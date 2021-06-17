using AutoMapper;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
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
    public class EfCreateBrandCommand : ICreateBrandCommand
    {
        private readonly BilliardShopContext _context;
        private readonly CreateBrandValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateBrandCommand(BilliardShopContext context, CreateBrandValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Create Brand using EF";

        public void Execute(BrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = _mapper.Map<Domain.Brand>(request);

            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

    }

}
