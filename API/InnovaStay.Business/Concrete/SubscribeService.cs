using InnovaStay.Business.Abstract;
using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos.Subscribe;
using InnovaStay.Dto.Dtos.Testimonial;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Concrete
{
    public class SubscribeService : GenericService<SubscribeDto, Subscribe>,ISubscribeService
    {
        public SubscribeService(IGenericRepository<Subscribe> repository) : base(repository)
        {
        }
    }
}
