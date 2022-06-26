using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mapper.Interfaces;
using Services.Dtos.Book;

namespace Mapper.Mappers
{
    public class BorrowerMapper : BaseMapper<BaseBookDto>, IBorrowerMapper
    {
        public BorrowerMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}
