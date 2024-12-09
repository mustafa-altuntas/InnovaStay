using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos.Service;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Concrete
{
    public class ServiceService : GenericService<ServiceDto, Service>
    {
        public ServiceService(IGenericRepository<Service> repository) : base(repository)
        {
        }
    }
}
