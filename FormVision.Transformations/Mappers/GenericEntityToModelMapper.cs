using System;
using AutoMapper;
using AutoMapper.Mappers;
using FormVision.DO.Entities;
using FormVision.Models.Models;

namespace FormVision.Transformations.Mappers
{
    class GenericEntityToModelMapper<TEntity, TEntityModel> : IEntityToModelMapper<TEntity, TEntityModel>
        where TEntity : IEntity where TEntityModel : IEntityModel
    {
        private readonly IMapper _mapper;

        public GenericEntityToModelMapper()
        {
            var config = new MapperConfiguration(InitMapping);
            _mapper = config.CreateMapper();
        }

        public virtual void InitMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TEntity, TEntityModel>();
        }

        public virtual TEntityModel MapToModel(TEntity entity)
        {
            var model = _mapper.Map<TEntity, TEntityModel>(entity);
            return model;
        }

        public TEntityModel MapToExistingModel(TEntity entity, TEntityModel model)
        {
            var updatedModel = _mapper.Map<TEntity, TEntityModel>(entity, model);
            return updatedModel;
        }
    }
}