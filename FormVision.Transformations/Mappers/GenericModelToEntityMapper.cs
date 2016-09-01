using System;
using AutoMapper;
using AutoMapper.Mappers;
using FormVision.DO.Entities;
using FormVision.Models.Models;
using FreshTinyIoC;

namespace FormVision.Transformations.Mappers
{
    class GenericModelToEntityMapper<TEntityModel, TEntity> : IModelToEntityMapper<TEntityModel, TEntity>
        where TEntityModel : IEntityModel where TEntity : IEntity
    {
        private readonly IMapper _mapper;

        public GenericModelToEntityMapper()
        {
            var config = new MapperConfiguration(InitMapping);
            _mapper = config.CreateMapper();
        }

        public virtual void InitMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TEntityModel, TEntity>();
        }

        public virtual TEntity MapToEntity(TEntityModel model)
        {
            var entity = _mapper.Map<TEntityModel, TEntity>(model);
            return entity;
        }

        public TEntity MapToExistingEntity(TEntityModel model, TEntity entity)
        {
            var updatedEntity = _mapper.Map<TEntityModel, TEntity>(model, entity);
            return updatedEntity;
        }
    }
}