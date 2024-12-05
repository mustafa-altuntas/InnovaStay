using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id); // Belirli bir varlığı getirir.
        Task<IEnumerable<TEntity>> GetAllAsync(); // Tüm varlıkları getirir.
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate); // Koşula göre veri getirir.

        Task AddAsync(TEntity entity); // Yeni varlık ekler.
        Task AddRangeAsync(IEnumerable<TEntity> entities); // Birden fazla varlık ekler.

        void Update(TEntity entity); // Varlığı günceller.
        void Remove(TEntity entity); // Belirli bir varlığı siler.
        void RemoveRange(IEnumerable<TEntity> entities); // Birden fazla varlığı siler.

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate); // Belirli bir koşula göre veri var mı kontrol eder.
        IQueryable<TEntity> AsQueryable(); // Dinamik sorgulamalar için


    }
}
