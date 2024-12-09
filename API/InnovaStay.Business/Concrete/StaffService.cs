using InnovaStay.Data.Abstract;
using InnovaStay.Dto.Dtos.Staff;
using InnovaStay.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaStay.Business.Concrete
{
    public class StaffService : GenericService<StaffDto, Staff>
    {
        public StaffService(IGenericRepository<Staff> repository) : base(repository)
        {
        }
    }
}
