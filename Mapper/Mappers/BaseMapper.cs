using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Entities;
using Mapper.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.Dtos;

namespace Mapper.Mappers
{
    public class BaseMapper<T> : IBaseMapper<T> where T : BaseDto
    {
        private readonly IMapper _mapper;

        public BaseMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual TDto EntityToDto<TEntity, TDto>(TEntity source)
            where TEntity : BaseEntity
            where TDto : T
        => _mapper.Map<TDto>(source);

        public virtual TEntity DtoToEntity<TDto, TEntity>(TDto source)
            where TEntity : BaseEntity
            where TDto : T
            => _mapper.Map<TEntity>(source);
    }
}
