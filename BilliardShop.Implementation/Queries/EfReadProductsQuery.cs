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
    public class EfReadProductsQuery : IReadProductsQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadProductsQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 12;

        public string Name => "Read Products using EF";

        public PagedResponse<ReadProductDto> Execute(ProductSearch search)
        {
            var query = _context.Products.Include(x => x.OrderLines).Include(x => x.Brand).Include(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.BrandName) || !string.IsNullOrWhiteSpace(search.BrandName))
            {
                query = query.Where(x => x.Brand.Name.ToLower().Contains(search.BrandName.ToLower()));
            }
            if (search.BrandId != null)
            {
                query = query.Where(x => x.BrandId == search.BrandId);
            }
            if (!string.IsNullOrEmpty(search.CategoryName) || !string.IsNullOrWhiteSpace(search.CategoryName))
            {
                query = query.Where(x => x.Category.Name.ToLower().Contains(search.CategoryName.ToLower()));
            }
            if (search.CategoryId != null)
            {
                query = query.Where(x => x.CategoryId == search.CategoryId);
            }


            var queryPaged = query.AsPagedResponse(search.PerPage, search.Page);
            return new PagedResponse<ReadProductDto>()
            {
                CurrentPage = queryPaged.CurrentPage,
                ItemsPerPage = queryPaged.ItemsPerPage,
                TotalCount = queryPaged.TotalCount,
                Items = _mapper.Map<IEnumerable<ReadProductDto>>(queryPaged.Items)
            };
        }
    }

}
