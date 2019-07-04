using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Otakon.Library.Infra.DataAcess.SqlServer.EF
{
    public abstract class DataContext<TEntity>  where TEntity : class
    {
        protected readonly DbClient _db;

        public DataContext(IConfiguration configuration)
        {
            _db = new DbClient(configuration);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Find(predicate);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().FindAsync(predicate);
        }

        public virtual IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual void Insert(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
        }

        public virtual void InsertMany(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().AddRange(entities);
        }

        public virtual async Task InsertManyAsync(IEnumerable<TEntity> entities)
        {
            await _db.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateMany(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().UpdateRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteMany(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().RemoveRange(entities);
        }

        public bool Commit()
        {
            return _db.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
