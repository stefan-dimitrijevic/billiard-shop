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
    public class EfReadOrderQuery : IReadOrderQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadOrderQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 23;

        public string Name => "Read Order using EF";

        public ReadOrderDto Execute(int search)
        {
            var order = _context.Orders.Include(x => x.User).Include(x => x.OrderLines).ThenInclude(x => x.Product).ThenInclude(x => x.Brand).FirstOrDefault(x => x.Id == search);

            if (order == null)
            {
                throw new EntityNotFoundException(search, typeof(Order));
            }

            return _mapper.Map<ReadOrderDto>(order);
        }
    }

}
