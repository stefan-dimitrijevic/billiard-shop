using AutoMapper;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Queries;
using BilliardShop.Application.Searches;
using BilliardShop.EfDataAccess;
using BilliardShop.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Queries
{
    public class EfReadBrandsQuery : IReadBrandsQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadBrandsQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Read Brands using EF";

        public PagedResponse<ReadBrandDto> Execute(BrandSearch search)
        {
            var query = _context.Brands.Include(x => x.Products).ThenInclude(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var queryPaged = query.AsPagedResponse(search.PerPage, search.Page);
            return new PagedResponse<ReadBrandDto>()
            {
                CurrentPage = queryPaged.CurrentPage,
                ItemsPerPage = queryPaged.ItemsPerPage,
                TotalCount = queryPaged.TotalCount,
                Items = _mapper.Map<IEnumerable<ReadBrandDto>>(queryPaged.Items)
            };
        }
    }
}
