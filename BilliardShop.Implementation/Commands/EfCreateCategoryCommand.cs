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
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly BilliardShopContext _context;
        private readonly CreateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCategoryCommand(BilliardShopContext context, CreateCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 6;

        public string Name => "Create new Category using EF";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = _mapper.Map<Domain.Category>(request);

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }

}
