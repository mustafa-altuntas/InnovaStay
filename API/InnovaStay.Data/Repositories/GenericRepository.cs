using InnovaStay.Data.Abstract;
using InnovaStay.Data.Concrete;
using InnovaStay.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class,IBaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;


        public GenericRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }


        public async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.OrderBy(x=>x.Id).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var value = await _dbSet.FindAsync(id);
            if (value != null)
            {
                _dbSet.Entry(value).State = EntityState.Detached;
            }
            return value;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            _dbContext.SaveChanges();

        }

        public void Update(TEntity entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
