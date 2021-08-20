using Acerpro.Data.Abstruct;
using Acerpro.Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Acerpro.Data.Concreate
{
    //Generic Repository class
    public class Context<TEntity, TContext> : IContext<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public async Task<TEntity> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var result = context.Entry(entity);
                result.State = EntityState.Added;
                await context.SaveChangesAsync();
                return result.Entity;
            };
        }

        public async Task<bool> Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var result = context.Entry(entity);
                result.State = EntityState.Deleted;
                return await context.SaveChangesAsync() > 0;
            };
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext()) {
                if (filter != null)
                    return await context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
                return await context.Set<TEntity>().FirstOrDefaultAsync();
            };
        }

        public async Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext()) {
                if (filter != null)
                    return await context.Set<TEntity>().Where(filter).ToListAsync();
                return await context.Set<TEntity>().ToListAsync();
            };
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new TContext()) {
                var result = context.Entry(entity);
                result.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return result.Entity;
            };
        }
    }
}
