using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FormVision.DO.Entities;
using FormVision.Models.Models;

namespace FormVision.Services.Abstractions.Repositories
{
    public interface IRepository<TEntity, TEntityModel> where TEntity : IEntity
        where TEntityModel : IEntityModel
    {
        Task<IQueryable<TEntityModel>> Query(Expression<Func<TEntity, bool>> wherePredicate=null, int offset=0, int maxCount=0 );
        TEntityModel Get(Guid id);
        TEntityModel Save(TEntityModel model);
        Task Delete(Guid id);
    }
}
