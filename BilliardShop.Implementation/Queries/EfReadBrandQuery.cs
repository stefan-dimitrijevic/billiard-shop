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
    public class EfReadBrandQuery : IReadBrandQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadBrandQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Read Brands using EF";

        public ReadBrandDto Execute(int search)
        {
            var brand = _context.Brands.Include(x => x.Products).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == search);

            if (brand == null)
            {
                throw new EntityNotFoundException(search, typeof(Brand));
            }

            return _mapper.Map<ReadBrandDto>(brand);
        }
    }
}
