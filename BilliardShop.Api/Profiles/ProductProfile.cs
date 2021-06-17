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
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ReadProductDto>()
                .ForMember(dto => dto.Brand, opt => opt.MapFrom(product => product.Brand.Name))
                .ForMember(dto => dto.Category, opt => opt.MapFrom(product => product.Category.Name))
                .ForMember(dto => dto.OrderLines, opt => opt.MapFrom(product => product.OrderLines.Select(x => new OrderLineDto
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    ProductId = x.ProductId
                })));

            CreateMap<ProductDto, Product>();

        }
    }
}
