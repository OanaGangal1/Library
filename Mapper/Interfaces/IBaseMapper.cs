using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Services.Dtos;

namespace Mapper.Interfaces;
public interface IBaseMapper<T> where T : BaseDto
{
    TDto EntityToDto<TEntity, TDto>(TEntity source)
        where TEntity : BaseEntity
        where TDto : T;

    TEntity DtoToEntity<TDto, TEntity>(TDto source)
        where TEntity : BaseEntity
        where TDto : T;
}
