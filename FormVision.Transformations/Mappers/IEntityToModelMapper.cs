using AutoMapper;
using FormVision.DO.Entities;
using FormVision.Models.Models;

namespace FormVision.Transformations.Mappers
{
    public interface IEntityToModelMapper
    {
        void InitMapping(IMapperConfigurationExpression cfg);
    }

    public interface IEntityToModelMapper<in TEntity, TEntityModel> : IEntityToModelMapper where TEntity : IEntity
        where TEntityModel : IEntityModel
    {
        TEntityModel MapToModel(TEntity entity);
        TEntityModel MapToExistingModel(TEntity entity, TEntityModel model);
    }
}