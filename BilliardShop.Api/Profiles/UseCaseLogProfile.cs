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
    public class UseCaseLogProfile : Profile
    {
        public UseCaseLogProfile()
        {
            CreateMap<UseCaseLog, UseCaseLogDto>();
        }
    }
}
