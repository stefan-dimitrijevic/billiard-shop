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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Commands
{
    public class EfUpdateProductCommand : IUpdateProductCommand
    {
        private readonly BilliardShopContext _context;
        private readonly UpdateProductValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateProductCommand(BilliardShopContext context, UpdateProductValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 14;

        public string Name => "Update Product using EF";

        public void Execute(ProductDto request)
        {
            var product = _context.Products.Find(request.Id);

            if (product == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Product));
            }

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

            _mapper.Map(request, product);
            _context.SaveChanges();
        }
    }

}
