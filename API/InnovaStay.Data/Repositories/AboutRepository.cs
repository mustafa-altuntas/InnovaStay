using InnovaStay.Data.Abstract;
using InnovaStay.Data.Concrete;
using InnovaStay.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace InnovaStay.Data.Repositories
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<About?> GetByActiveAsync()
        {
            var about = await _dbSet.FirstOrDefaultAsync(a => a.İsActive);
            if (about == null)
                return null;
            return about;
        }

        /// <summary>
        /// Bu method yanlızca bir About deperini aktif yapar. Eğer başka aktif About değeri varsa o kayıtlar pasif edilir.
        /// </summary>
        /// <param name="id">Aktif edilmek istenen kaydın id değeri.</param>
        /// <returns>İşlem başarılı ise true değeri döner.</returns>
        public async Task<bool> MarkAsActivateAsycn(int id)
        {
            var activeAbouts = _dbSet.Where(a => a.İsActive).ToList();
            activeAbouts.ForEach(a => a.İsActive = false);

            var about = await _dbSet.FindAsync(id);
            if(about != null)
            {
                about.İsActive = true;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
