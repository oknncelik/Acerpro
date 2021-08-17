using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Acerpro.Data.Abstruct
{
    public interface IContext<TEntity>
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}
