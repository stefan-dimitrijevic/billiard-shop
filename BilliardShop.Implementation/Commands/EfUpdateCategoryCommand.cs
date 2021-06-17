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
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly BilliardShopContext _context;
        private readonly UpdateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCategoryCommand(BilliardShopContext context, UpdateCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Update Category using EF";

        public void Execute(CategoryDto request)
        {
            var category = _context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, category);
            _context.SaveChanges();
        }
    }

}
