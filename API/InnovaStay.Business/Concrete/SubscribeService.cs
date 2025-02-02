using InnovaStay.Business.Abstract;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.Subscribe;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Concrete
{
    public class SubscribeService : GenericService<SubscribeDto, Subscribe>,ISubscribeService
    {
        public SubscribeService(IGenericRepository<Subscribe> repository) : base(repository)
        {
        }
    }
}
