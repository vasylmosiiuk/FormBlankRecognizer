using AutoMapper;
using FormVision.DO.Entities;
using FormVision.Models.Models;

namespace FormVision.Transformations.Mappers
{
    public interface IModelToEntityMapper
    {
        void InitMapping(IMapperConfigurationExpression cfg);
    }

    public interface IModelToEntityMapper<in TEntityModel, TEntity> : IModelToEntityMapper where TEntity : IEntity
        where TEntityModel : IEntityModel
    {
        TEntity MapToEntity(TEntityModel model);
        TEntity MapToExistingEntity(TEntityModel model, TEntity entity);
    }
}