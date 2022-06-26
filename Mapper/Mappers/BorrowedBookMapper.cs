using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mapper.Interfaces;
using Services.Dtos.BorrowedBook;

namespace Mapper.Mappers
{
    public class BorrowedBookMapper : BaseMapper<BaseBorrowedBookDto>, IBorrowedBookMapper
    {
        public BorrowedBookMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}
