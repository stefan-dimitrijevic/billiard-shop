using AutoMapper;
using BilliardShop.Application.DataTransfer;
using BilliardShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ReadUserDto>()
                .ForMember(dto => dto.Orders, opt => opt.MapFrom(user => user.Orders.Select(x => new ReadOrderDto
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    OrderDate = x.OrderDate,
                    ShippedDate = x.ShippedDate,
                    Address = x.Address,
                    UserId = x.UserId,
                    UserInfo = x.User.FirstName + " " + x.User.LastName,
                    StatusName = x.Status.ToString(),
                    OrderLines = x.OrderLines.Select(y => new OrderLineDto
                    {
                        Id = y.Id,
                        OrderId = y.OrderId,
                        Quantity = y.Quantity,
                        ProductId = y.ProductId,
                        Price = y.Price
                    }),
                    TotalPrice = x.OrderLines.Sum(x => x.Price * x.Quantity)
                })));

            CreateMap<UserDto, User>();
        }
    }
}
