using InnovaStay.Entity.Concrete;

namespace InnovaStay.Data.Abstract
{
    public interface IAboutRepository : IGenericRepository<About>
    {
        Task<bool> MarkAsActivateAsycn(int id);
        Task<About?> GetByActiveAsync();

    }
}
