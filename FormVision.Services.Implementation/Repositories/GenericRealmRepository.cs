using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FormVision.DO.Entities;
using FormVision.Models.Models;
using FormVision.Services.Abstractions.Repositories;
using FormVision.Transformations.Mappers;
using Realms;

namespace FormVision.Services.Implementation.Repositories
{
    internal class GenericRealmRepository<TEntity, TEntityModel> : IRepository<TEntity, TEntityModel>
        where TEntity : RealmObject, IEntity, new()
        where TEntityModel : IEntityModel
    {
        private readonly IEntityToModelMapper<TEntity, TEntityModel> _entityToModelMapper;
        private readonly IModelToEntityMapper<TEntityModel, TEntity> _modelToEntityModelMapper;
        private readonly Realm _realm;

        public GenericRealmRepository(Realm realm, IEntityToModelMapper<TEntity, TEntityModel> entityToModelMapper,
            IModelToEntityMapper<TEntityModel, TEntity> modelToEntityModelMapper)
        {
            _realm = realm;
            _entityToModelMapper = entityToModelMapper;
            _modelToEntityModelMapper = modelToEntityModelMapper;
        }

        public async Task<IQueryable<TEntityModel>> Query(Expression<Func<TEntity, bool>> wherePredicate = null,
            int offset = 0, int maxCount = 0)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (maxCount < 0)
                throw new ArgumentOutOfRangeException(nameof(maxCount));

            IQueryable<TEntity> entities = _realm.All<TEntity>();
            if (wherePredicate != null)
                entities = entities.Where(wherePredicate);
            if (offset > 0)
                entities = entities.Skip(offset);
            if (maxCount > 0)
                entities = entities.Take(maxCount);
            var filteredItems = entities.Select(_entityToModelMapper.MapToModel).AsQueryable();
            return filteredItems;
        }

        public TEntityModel Get(Guid id)
        {
            var entity = GetEntity(id);
            if (entity == null)
                return default(TEntityModel);
            var model = _entityToModelMapper.MapToModel(entity);
            return model;
        }

        public TEntityModel Save(TEntityModel model)
        {
            if (model.Id != Guid.Empty)
            {
                //update
                var existingEntity = GetEntity(model.Id);
                if (existingEntity == null)
                    throw new InvalidOperationException(
                        $"There are no {typeof (TEntity).Name} with Id:{model.Id.ToString("N")}");
                var updatedEntity = _modelToEntityModelMapper.MapToExistingEntity(model, existingEntity);
                return _entityToModelMapper.MapToModel(updatedEntity);
            }
            //create
            var entityToCreate = _realm.CreateObject<TEntity>();
            model.Id = Guid.NewGuid();
            var createdEntity = _modelToEntityModelMapper.MapToExistingEntity(model, entityToCreate);
            return _entityToModelMapper.MapToModel(createdEntity);
        }

        public async Task Delete(Guid id)
        {
            var existingEntity = GetEntity(id);
            if (existingEntity == null)
                throw new InvalidOperationException(
                    $"There are no {typeof(TEntity).Name} with Id:{id.ToString("N")}");
            _realm.Remove(existingEntity);
        }

        private TEntity GetEntity(Guid id)
        {
            var entity = _realm.All<TEntity>().SingleOrDefault(x => x.Id == id);
            return entity;
        }
    }
}