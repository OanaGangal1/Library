using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Entities;
using Services.Dtos.Borrower;

namespace Mapper.Profiles
{
    public class BorrowerProfile : Profile
    {
        public BorrowerProfile()
        {
            CreateMap<Borrower, BorrowerDto>().ReverseMap();
        }
    }
}
