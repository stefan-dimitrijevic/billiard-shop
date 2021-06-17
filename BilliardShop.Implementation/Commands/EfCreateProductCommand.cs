using AutoMapper;
using BilliardShop.Application.Commands;
using BilliardShop.Application.DataTransfer;
using BilliardShop.EfDataAccess;
using BilliardShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Commands
{
    public class EfCreateProductCommand : ICreateProductCommand
    {
        private readonly BilliardShopContext _context;
        private readonly CreateProductValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateProductCommand(BilliardShopContext context, CreateProductValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Create new Product using EF";

        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

            request.ImagePath = newFileName.ToString();

            var project = _mapper.Map<Domain.Product>(request);

            _context.Products.Add(project);
            _context.SaveChanges();
        }
    }

}
