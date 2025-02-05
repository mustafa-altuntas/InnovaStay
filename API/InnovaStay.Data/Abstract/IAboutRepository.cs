using InnovaStay.Entity.Concrete;

namespace InnovaStay.Data.Abstract
{
    public interface IAboutRepository : IGenericRepository<About>
    {
        Task<bool> MarkAsActivate(int id);
    }
}
