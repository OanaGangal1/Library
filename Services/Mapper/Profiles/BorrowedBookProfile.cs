using AutoMapper;
using DataLayer.Entities;
using Services.Dtos.BorrowedBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.Profiles
{
    public class BorrowedBookProfile : Profile
    {
        public BorrowedBookProfile()
        {
            CreateMap<BorrowBook, BorrowedBookDto>()
                .ForMember(dest => dest.BookName,
                    opt => opt.MapFrom(x => x.Book != null
                        ? x.Book.Name
                        : ""))
                .ForMember(dest => dest.BorrowerFullName,
                    opt => opt.MapFrom(x => x.Borrower != null
                        ? x.Borrower.FirstName + " " + x.Borrower.LastName
                        : ""));

            CreateMap<BorrowedBookDto, BorrowBook>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
