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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ReadOrderDto>()
                .ForMember(dto => dto.UserInfo, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName))
                .ForMember(dto => dto.StatusName, opt => opt.MapFrom(x => x.Status.ToString()))
                .ForMember(dto => dto.OrderLines, opt => opt.MapFrom(order => order.OrderLines.Select(x => new OrderLineDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    Quantity = x.Quantity,
                    ProductId = x.ProductId,
                    Price = x.Price
                })))
                .ForMember(dto => dto.TotalPrice, opt => opt.MapFrom(order => order.OrderLines.Sum(x => x.Price * x.Quantity)));

            CreateMap<OrderDto, Order>();
        }
    }
}
