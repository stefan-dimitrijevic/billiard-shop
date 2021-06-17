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
    public class EfReadUsersQuery : IReadUsersQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadUsersQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 17;

        public string Name => "Read Users using EF";

        public PagedResponse<ReadUserDto> Execute(UserSearch search)
        {
            var query = _context.Users.Include(x => x.Orders).ThenInclude(x => x.OrderLines).ThenInclude(x => x.Product).AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) && !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.LastName) && !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            var queryPaged = query.AsPagedResponse(search.PerPage, search.Page);
            return new PagedResponse<ReadUserDto>()
            {
                CurrentPage = queryPaged.CurrentPage,
                ItemsPerPage = queryPaged.ItemsPerPage,
                TotalCount = queryPaged.TotalCount,
                Items = _mapper.Map<IEnumerable<ReadUserDto>>(queryPaged.Items)
            };
        }
    }

}
