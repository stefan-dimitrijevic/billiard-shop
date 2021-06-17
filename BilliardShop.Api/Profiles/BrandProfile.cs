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
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, ReadBrandDto>()
                .ForMember(dto => dto.Products, opt => opt.MapFrom(brand => brand.Products.Select(x => new ReadProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Brand = x.Brand.Name,
                    Category = x.Category.Name,
                    ImagePath = x.ImagePath,
                    Quantity = x.Quantity.Value,
                    Price = x.Price
                })));

            CreateMap<BrandDto, Brand>();
        }
    }
}
