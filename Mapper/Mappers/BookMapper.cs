using AutoMapper;
using Mapper.Interfaces;
using Services.Dtos.Book;

namespace Mapper.Mappers
{
    public class BookMapper : BaseMapper<BaseBookDto>, IBookMapper
    {
        public BookMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}