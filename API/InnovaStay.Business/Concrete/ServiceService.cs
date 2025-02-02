using InnovaStay.Business.Abstract;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos;
using InnovaStay.Dto.Dtos.Service;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Business.Concrete
{
    public class ServiceService : GenericService<ServiceDto, Service>,IServiceService
    {
        public ServiceService(IGenericRepository<Service> repository) : base(repository)
        {
        }
    }
}
