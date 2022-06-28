using AutoMapper;
using DataLayer.Entities;
using Services.Dtos.Borrower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.Profiles
{
    public class BorrowerProfile : Profile
    {
        public BorrowerProfile()
        {
            CreateMap<Borrower, BorrowerDto>();
            CreateMap<BorrowerDto, Borrower>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
