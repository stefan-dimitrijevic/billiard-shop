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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ReadCategoryDto>()
                .ForMember(dto => dto.Products, opt => opt.MapFrom(category => category.Products.Select(x => new ReadProductDto
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

            CreateMap<CategoryDto, Category>();
        }
    }
}
