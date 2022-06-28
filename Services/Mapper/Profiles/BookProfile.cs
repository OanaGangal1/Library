using AutoMapper;
using DataLayer.Entities;
using Services.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Isbn, opt => opt.Ignore());

            CreateMap<Book, AddBookDto>();

            CreateMap<AddBookDto, Book>();
        }
    }
}
