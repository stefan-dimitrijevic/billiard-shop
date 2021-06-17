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
    public class EfReadCategoryQuery : IReadCategoryQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadCategoryQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 8;

        public string Name => "Read Category using EF";

        public ReadCategoryDto Execute(int search)
        {
            var category = _context.Categories.Include(x => x.Products).ThenInclude(x => x.Brand).FirstOrDefault(x => x.Id == search);

            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }

            return _mapper.Map<ReadCategoryDto>(category);
        }
    }

}
