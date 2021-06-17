using AutoMapper;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Exceptions;
using BilliardShop.Application.Queries;
using BilliardShop.Domain;
using BilliardShop.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Queries
{
    public class EfReadProductQuery : IReadProductQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadProductQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 13;

        public string Name => "Read Product using EF";

        public ReadProductDto Execute(int search)
        {
            var product = _context.Products.Include(x => x.OrderLines).Include(x => x.Category).Include(x => x.Brand).FirstOrDefault(x => x.Id == search);

            if (product == null)
            {
                throw new EntityNotFoundException(search, typeof(Product));
            }

            return _mapper.Map<ReadProductDto>(product);
        }
    }

}
