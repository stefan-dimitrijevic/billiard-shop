using AutoMapper;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Queries;
using BilliardShop.Application.Searches;
using BilliardShop.EfDataAccess;
using BilliardShop.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Queries
{
    public class EfReadUserUseCasesQuery : IReadUserUseCasesQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadUserUseCasesQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 28;

        public string Name => "Read Use cases using EF";

        public PagedResponse<UserUseCaseDto> Execute(UserUseCaseSearch search)
        {
            var query = _context.UserUseCases.AsQueryable();

            if (search.UseCaseId != null)
            {
                query = query.Where(x => x.UseCaseId == search.UseCaseId);
            }
            if (search.UserId != null)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            var queryPaged = query.AsPagedResponse(search.PerPage, search.Page);
            return new PagedResponse<UserUseCaseDto>
            {
                CurrentPage = queryPaged.CurrentPage,
                ItemsPerPage = queryPaged.ItemsPerPage,
                TotalCount = queryPaged.TotalCount,
                Items = _mapper.Map<IEnumerable<UserUseCaseDto>>(queryPaged.Items)
            };
        }
    }

}
