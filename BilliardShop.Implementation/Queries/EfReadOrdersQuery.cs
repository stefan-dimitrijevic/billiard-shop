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
    public class EfReadOrdersQuery : IReadOrdersQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadOrdersQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 22;

        public string Name => "Read Orders using EF";

        public PagedResponse<ReadOrderDto> Execute(OrderSearch search)
        {
            var query = _context.Orders.Include(x => x.User).Include(x => x.OrderLines).ThenInclude(x => x.Product).ThenInclude(x => x.Brand).AsQueryable();

            if (search.MinCreatedAt != null)
            {
                query = query.Where(x => x.CreatedAt >= search.MinCreatedAt);
            }
            if (search.MaxCreatedAt != null)
            {
                query = query.Where(x => x.CreatedAt <= search.MaxCreatedAt);
            }
            if (search.MinOrderDate != null)
            {
                query = query.Where(x => x.OrderDate >= search.MinOrderDate);
            }
            if (search.MaxOrderDate != null)
            {
                query = query.Where(x => x.OrderDate <= search.MinOrderDate);
            }
            if (search.MinShippedDate != null)
            {
                query = query.Where(x => x.ShippedDate >= search.MinShippedDate);
            }
            if (search.MaxShippedDate != null)
            {
                query = query.Where(x => x.ShippedDate <= search.MaxShippedDate);
            }
            if (search.MinTotalPrice != null)
            {
                query = query.Where(x => x.OrderLines.Sum(y => y.Price * y.Quantity) >= search.MinTotalPrice);
            }
            if (search.MaxTotalPrice != null)
            {
                query = query.Where(x => x.OrderLines.Sum(y => y.Price * y.Quantity) <= search.MaxTotalPrice);
            }
            if (!string.IsNullOrEmpty(search.Address) || !string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Address.ToLower()));
            }
            if (search.UserId != null)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            if (search.Status != null)
            {
                query = query.Where(x => x.Status == search.Status);
            }

            var queryPaged = query.AsPagedResponse(search.PerPage, search.Page);
            return new PagedResponse<ReadOrderDto>()
            {
                CurrentPage = queryPaged.CurrentPage,
                ItemsPerPage = queryPaged.ItemsPerPage,
                TotalCount = queryPaged.TotalCount,
                Items = _mapper.Map<IEnumerable<ReadOrderDto>>(queryPaged.Items)
            };
        }
    }

}
