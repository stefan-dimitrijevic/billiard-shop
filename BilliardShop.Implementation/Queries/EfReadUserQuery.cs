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
    public class EfReadUserQuery : IReadUserQuery
    {
        private readonly BilliardShopContext _context;
        private readonly IMapper _mapper;

        public EfReadUserQuery(BilliardShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Read User using EF";

        public ReadUserDto Execute(int search)
        {
            var user = _context.Users.Include(x => x.Orders).ThenInclude(x => x.OrderLines).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == search);

            if (user == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            return _mapper.Map<ReadUserDto>(user);
        }
    }

}
